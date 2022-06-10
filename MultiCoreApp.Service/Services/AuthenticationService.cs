using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;
using MultiCoreApp.Core.Responses;
using MultiCoreApp.DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;
        public AuthenticationService(IUserService userService,ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;

        }
        public BaseResponse<AccessToken> CreateAccessToken(string email, string password)
        {
            BaseResponse<User> userResponse = _userService.FindByEmailPassword(email,password);
            if (userResponse.Success)
            {
                AccessToken accessToken = _tokenHandler.CreateAccessToken(userResponse.Extra);
                _userService.SaveRefreshToken(userResponse.Extra.Id,accessToken.RefreshToken);
                return new BaseResponse<AccessToken>(accessToken);

            }
            else
            {
                return new BaseResponse<AccessToken>(userResponse.ErrorMessage);
            }
        }

        public BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = _userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {

                if (userResponse.Extra.RefreshTokenEndDate>DateTime.Now)
                {
                    AccessToken accessToken = _tokenHandler.CreateAccessToken(userResponse.Extra);
                    _userService.SaveRefreshToken(userResponse.Extra.Id, accessToken.RefreshToken);
                    return new BaseResponse<AccessToken>(accessToken);
                }
                else
                {
                    return new BaseResponse<AccessToken>("Refresh Token Kullanım süresi dolmustur");
                }

            }
            else
            {
                return new BaseResponse<AccessToken>("Refresh token bulunamadi"+userResponse.ErrorMessage);
            }
        }

        public BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken)
        {
            BaseResponse<User> userResponse = _userService.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Success)
            {
                _userService.RemoveRefreshToken(userResponse.Extra);
                return new BaseResponse<AccessToken>(new AccessToken());

            }
            else
            {
                return new BaseResponse<AccessToken>("Refresh token bulunamadi :"+userResponse.ErrorMessage);
            }
        }
    }
}
