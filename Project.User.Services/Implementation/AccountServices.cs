using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnTime.Comman.Idenitity;
using OnTime.CrossCutting.Comman.Exception;
using OnTime.CrossCutting.Comman.Time;
using OnTime.Data.IGenericRepository_IUOW;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILdapAuthenticator _ldapAuthenticator;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtOptions _jwtOptions;
        private readonly AdminUsersOptions _adminUsers;
        private readonly UserManager<ApplicationUser> _userRepository;

        public AccountServices(
            IJwtServices jwtServices,
            ISettingsProvider settingsProvider,
           IUnitOfWork unitOfWork,
            ILdapAuthenticator ldapAuthenticator,
            IDateTimeProvider dateTimeProvider,
            IOptions<JwtOptions> jwtOptions,
            IOptions<AdminUsersOptions> adminUsers, UserManager<ApplicationUser> userRepository)
        {
            _jwtServices = jwtServices ?? throw new ArgumentNullException(nameof(jwtServices));
            _settingsProvider = settingsProvider ?? throw new ArgumentNullException(nameof(settingsProvider));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _ldapAuthenticator = ldapAuthenticator ?? throw new ArgumentNullException(nameof(ldapAuthenticator));
            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _jwtOptions = jwtOptions?.Value ?? new JwtOptions();
            _adminUsers = adminUsers?.Value ?? new AdminUsersOptions();
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        //public async Task<AuthenticatedResponse> Login(LoginInformation loginInformation, CancellationToken cancellationToken = default)
        //{
        //    if (string.IsNullOrWhiteSpace(loginInformation?.Username))
        //        throw new ApiException("server.invalidLogin");

        //    var ldapSettings = await _settingsProvider.GetLdapSettings(cancellationToken);

        //    var isAdminLogin = _adminUsers.AdminUserNames.Any(a => loginInformation.Username.Contains(a, StringComparison.OrdinalIgnoreCase));

        //    ApplicationUser? user;

        //    if (isAdminLogin)
        //    {
        //        user = await _unitOfWork.Users.FindByNameAsync(loginInformation.Username.Trim(), cancellationToken)
        //               ?? throw new ApiException("server.invalidLogin");

        //        var signInResult = await usem.CheckPasswordSignInAsync(user, loginInformation.Password, lockoutOnFailure: false, cancellationToken);
        //        if (!signInResult.Succeeded) throw new ApiException("server.invalidLogin");
        //    }
        //    else if (ldapSettings.IsActive)
        //    {
        //        var loginSucceeded = await _ldapAuthenticator.ValidateAsync(loginInformation.Username.Trim(), loginInformation.Password, loginWithoutPassword: false, cancellationToken);
        //        if (!loginSucceeded) throw new ApiException("server.invalidLogin");

        //        var resolvedUsername = $"{loginInformation.Username.Trim()}@{ldapSettings.LdapDomain}";
        //        user = await _userRepository.FindByNameAsync(resolvedUsername, cancellationToken)
        //               ?? throw new ApiException("server.invalidLogin");
        //    }
        //    else
        //    {
        //        throw new ApiException("server.invalidLogin");
        //    }

        //    return await CreateAndReturnAuthResponseAsync(user, cancellationToken);
        //}

        //public async Task<AuthenticatedResponse> LoginWithLdap(LoginInformation loginInformation, CancellationToken cancellationToken = default)
        //{
        //    var ldapSettings = await _settingsProvider.GetLdapSettings(cancellationToken);
        //    if (!ldapSettings.IsActive) throw new ApiException("server.invalidLdapSettings");
        //    if (string.IsNullOrWhiteSpace(loginInformation?.Username)) throw new ApiException("server.invalidLogin");

        //    var loginSucceeded = await _ldapAuthenticator.ValidateAsync(loginInformation.Username.Trim(), loginInformation.Password, loginWithoutPassword: true, cancellationToken);
        //    if (!loginSucceeded) throw new ApiException("server.invalidLogin");

        //    var resolvedUsername = $"{loginInformation.Username.Trim()}@{ldapSettings.LdapDomain}";
        //    var user = await _userRepository.FindByNameAsync(resolvedUsername, cancellationToken)
        //               ?? throw new ApiException("server.invalidLogin");

        //    return await CreateAndReturnAuthResponseAsync(user, cancellationToken);
        //}

        //public Task<AuthenticatedResponse> LoginWithAzure(LoginWithAzureInformation loginInformation, CancellationToken cancellationToken = default)
        //{
        //    if (string.IsNullOrWhiteSpace(loginInformation?.Username)) throw new ApiException("server.invalidLogin");
        //    return _jwtServices.GenerateAzureJWTokenAsync(loginInformation);
        //}

        //public Task<AuthenticatedResponse> RefreshUserTokenAsync(UserRefreshToken userRefreshToken, CancellationToken cancellationToken = default)
        //{
        //    return _jwtServices.RefreshAsync(userRefreshToken);
        //}

        //private async Task<AuthenticatedResponse> CreateAndReturnAuthResponseAsync(ApplicationUser user, CancellationToken cancellationToken)
        //{
        //    var refreshToken = _jwtServices.GenerateRefreshToken();
        //    user.RefreshToken = refreshToken;
        //    user.RefreshTokenExpiryDate = _dateTimeProvider.UtcNow.AddMinutes(_jwtOptions.RefreshTokenExpireInMinutes);

        //    await _unitOfWork.Users.UpdateAsync(user);

        //    var authResponse = await _jwtServices.GenerateJWTokenAsync(user.Id);
        //    authResponse.RefreshToken = refreshToken;
        //    return authResponse;
        //}
 
    }
}
