using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnTime.ResponseHandler.Models;
using OnTime.Services.DataTransferObject.AuthenticationDto;
using OnTime.Services.Helpers;
using OnTime.Services.Interfaces;
using OnTime.User.Services.DTO;
using OnTime.User.Services.Implementation;
using OnTime.User.Services.Interfaces;
using System.Net;

namespace OnTime.User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        #region fields
        private readonly IAccountServices _authenticationService;
        private readonly IHelpureService _helpureService;
        #endregion

        #region ctor
        public AccountController(IAccountServices authenticationService, IHelpureService helpureService)
        {
            _authenticationService = authenticationService;
            _helpureService = helpureService;
        }
        #endregion




        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginInformation request)
        {

            var result = await _authenticationService.Login(request);

            return ProcessResponse(result);

        }

        [Authorize]
        [HttpGet("user-claims")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUserClaims()
        {
            var result = await _authenticationService.GetRoleClaimsOnlyAsync();


            return ProcessResponse(result);
        }
    }
}
