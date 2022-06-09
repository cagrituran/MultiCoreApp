using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MultiCoreApp.DataAccessLayer.Security
{
    public static class SignHandler
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
