using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using OnTime.Application.Common.Interfaces;
using OnTime.Comman.Idenitity;
using OnTime.CrossCutting.Comman.Exception;
using OnTime.CrossCutting.Comman.Idenitity;
using OnTime.CrossCutting.Comman.Time;
using OnTime.Data.IGenericRepository_IUOW;
using OnTime.ResponseHandler.Consts;
using OnTime.ResponseHandler.Models;
using OnTime.User.Services.DTO;
using OnTime.User.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.User.Services.Implementation
{
    public class AccountServices : IAccountServices
    {
        private readonly IJwtServices _jwtServices;
        private readonly ISettingsProvider _settingsProvider;
      //  private readonly IUnitOfWork _unitOfWork;
        private readonly ILdapAuthenticator _ldapAuthenticator;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtOptions _jwtOptions;
        private readonly AdminUsersOptions _adminUsers;
        private readonly UserManager<ApplicationUser> _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICurrentUserService _currentUserService;

        public AccountServices(
            IJwtServices jwtServices,
            ISettingsProvider settingsProvider,
//IUnitOfWork unitOfWork,
            ILdapAuthenticator ldapAuthenticator,
            IDateTimeProvider dateTimeProvider,
            IOptions<JwtOptions> jwtOptions,
            IOptions<AdminUsersOptions> adminUsers, UserManager<ApplicationUser> userRepository,
            SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, ICurrentUserService currentUserService)
        {
            _jwtServices = jwtServices ?? throw new ArgumentNullException(nameof(jwtServices));
            _settingsProvider = settingsProvider ?? throw new ArgumentNullException(nameof(settingsProvider));
           // _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _ldapAuthenticator = ldapAuthenticator ?? throw new ArgumentNullException(nameof(ldapAuthenticator));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _jwtOptions = jwtOptions?.Value ?? new JwtOptions();
            _adminUsers = adminUsers?.Value ?? new AdminUsersOptions();
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _signInManager = signInManager;
            _roleManager = roleManager;
            _currentUserService = currentUserService;
        }

        public async Task<APIOperationResponse<AuthenticatedResponse>> Login(
      LoginInformation loginInformation,
      CancellationToken cancellationToken = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginInformation?.Username))
                {
                    return APIOperationResponse<AuthenticatedResponse>.Fail(
                        ResponseType.BadRequest,
                        CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                        "server.invalidLogin");
                }

                var ldapSettings = await _settingsProvider.GetLdapSettings(cancellationToken);

                var isAdminLogin = true;
                    //_adminUsers.AdminUserNames
                   // .Any(a => loginInformation.Username.Contains(a, StringComparison.OrdinalIgnoreCase));

                ApplicationUser? user;

                if (isAdminLogin)
                {
                    user = await _userRepository.FindByNameAsync(loginInformation.Username.Trim());
                    if (user == null)
                    {
                        return APIOperationResponse<AuthenticatedResponse>.Fail(
                            ResponseType.Unauthorized,
                            CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                            "server.invalidLogin");
                    }

                    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginInformation.Password, lockoutOnFailure: false);
                    if (!signInResult.Succeeded)
                    {
                        return APIOperationResponse<AuthenticatedResponse>.Fail(
                            ResponseType.Unauthorized,
                            CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                            "server.invalidLogin");
                    }
                }
                else if (ldapSettings.IsActive)
                {
                    var loginSucceeded = await _ldapAuthenticator.ValidateAsync(
                        loginInformation.Username.Trim(),
                        loginInformation.Password,
                        loginWithoutPassword: false,
                        cancellationToken);

                    if (!loginSucceeded)
                    {
                        return APIOperationResponse<AuthenticatedResponse>.Fail(
                            ResponseType.Unauthorized,
                            CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                            "server.invalidLogin");
                    }

                    var resolvedUsername = $"{loginInformation.Username.Trim()}@{ldapSettings.LdapDomain}";
                    user = await _userRepository.FindByNameAsync(resolvedUsername);
                    if (user == null)
                    {
                        return APIOperationResponse<AuthenticatedResponse>.Fail(
                            ResponseType.Unauthorized,
                            CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                            "server.invalidLogin");
                    }
                }
                else
                {
                    return APIOperationResponse<AuthenticatedResponse>.Fail(
                        ResponseType.Unauthorized,
                        CommonErrorCodes.INVALID_EMAIL_OR_PASSWORD,
                        "server.invalidLogin");
                }

                var authResponse = await CreateAndReturnAuthResponseAsync(user, cancellationToken);

                return APIOperationResponse<AuthenticatedResponse>.Success(authResponse);
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return APIOperationResponse<AuthenticatedResponse>.Fail(
                    ResponseType.InternalServerError,
                    CommonErrorCodes.SERVER_ERROR,
                    ex.Message);
            }
        }


        public async Task<AuthenticatedResponse> LoginWithLdap(LoginInformation loginInformation, CancellationToken cancellationToken = default)
        {
            var ldapSettings = await _settingsProvider.GetLdapSettings(cancellationToken);
            if (!ldapSettings.IsActive) throw new ApiException("server.invalidLdapSettings");
            if (string.IsNullOrWhiteSpace(loginInformation?.Username)) throw new ApiException("server.invalidLogin");

            var loginSucceeded = await _ldapAuthenticator.ValidateAsync(loginInformation.Username.Trim(), loginInformation.Password, loginWithoutPassword: true, cancellationToken);
            if (!loginSucceeded) throw new ApiException("server.invalidLogin");

            var resolvedUsername = $"{loginInformation.Username.Trim()}@{ldapSettings.LdapDomain}";
            var user = await _userRepository.FindByNameAsync(resolvedUsername)
                       ?? throw new ApiException("server.invalidLogin");

            return await CreateAndReturnAuthResponseAsync(user, cancellationToken);
        }

        public Task<AuthenticatedResponse> LoginWithAzure(LoginWithAzureInformation loginInformation, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(loginInformation?.Username)) throw new ApiException("server.invalidLogin");
            return _jwtServices.GenerateAzureJWTokenAsync(loginInformation);
        }

        public Task<AuthenticatedResponse> RefreshUserTokenAsync(UserRefreshToken userRefreshToken, CancellationToken cancellationToken = default)
        {
            return _jwtServices.RefreshAsync(userRefreshToken);
        }

        private async Task<AuthenticatedResponse> CreateAndReturnAuthResponseAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var refreshToken = _jwtServices.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = _dateTimeProvider.UtcNow.AddMinutes(_jwtOptions.RefreshTokenExpireInMinutes);

            await _userRepository.UpdateAsync(user);

            var authResponse = await _jwtServices.GenerateJWTokenAsync(user.Id);
            authResponse.RefreshToken = refreshToken;
            return authResponse;
        }
        public async Task<APIOperationResponse<List<ClaimDto>>> GetRoleClaimsOnlyAsync()
        {
            var roleClaims = new List<ClaimDto>();

            // 1. Get the current user
            var user = await _userRepository.FindByIdAsync(_currentUserService.UserId);
            if (user == null)
                return APIOperationResponse < List < ClaimDto >>.Success(roleClaims);

            // 2. Get user roles
            var roles = await _userRepository.GetRolesAsync(user);

            // 3. Collect claims for each role
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var claims = await _roleManager.GetClaimsAsync(role);


                    roleClaims.AddRange(claims.Select
                          (x => new ClaimDto
                          {
                              Id = x.Value,
                              ClaimType = x.Type,

                          }));
                }
            }

            return APIOperationResponse<List<ClaimDto>>.Success(roleClaims);
        }

    }
}
