using MultiCoreApp.Core.Models;

using MultiCoreApp.DataAccessLayer.Security;

namespace MultiCoreApp.DataAccessLayer.Security
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);

        void RevokeRefreshToken(User user);
    }
}
