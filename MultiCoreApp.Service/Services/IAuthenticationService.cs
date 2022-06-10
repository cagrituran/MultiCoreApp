using MultiCoreApp.Core.Responses;
using MultiCoreApp.DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Service.Services
{
    public interface IAuthenticationService
    {
        BaseResponse<AccessToken> CreateAccessToken(string email,string password);
        BaseResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);
        BaseResponse<AccessToken> RevokeRefreshToken(string refreshToken);

    }
}
