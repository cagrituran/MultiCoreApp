using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user);
    }
}
