using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.API.Extensions;
using MultiCoreApp.Core.Responses;
using MultiCoreApp.DataAccessLayer.Security;
using MultiCoreApp.Service.Services;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService=authenticationService;
        }
        [HttpPost]
        public IActionResult AccessToken(LoginDto logindto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                BaseResponse<AccessToken> accessTokenResponse = _authenticationService.CreateAccessToken(logindto.Email, logindto.Password);
                if (accessTokenResponse.Success)
                {
                    return Ok(accessTokenResponse.Extra);
                }
                else
                {
                    return BadRequest(accessTokenResponse.ErrorMessage);
                }
            }
        }
        [HttpPost]
        public IActionResult RefreshToken(TokenDto tokenDto)
        {
            BaseResponse<AccessToken> accessTokenResponse = _authenticationService.CreateAccessTokenByRefreshToken(tokenDto.RefreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Extra);

            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }
        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenDto tokenDto)
        {
            BaseResponse<AccessToken> accessTokenResponse = _authenticationService.RevokeRefreshToken(tokenDto.RefreshToken);
            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.Extra);

            }
            else
            {
                return BadRequest(accessTokenResponse.ErrorMessage);
            }
        }
    }
}
