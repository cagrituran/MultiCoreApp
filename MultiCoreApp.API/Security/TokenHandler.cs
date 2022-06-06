using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiCoreApp.Core.Models;
using System.IdentityModel.Tokens.Jwt;

namespace MultiCoreApp.API.Security
{
    public class TokenHandler : ITokenHandler
    {
        private readonly CustomTokenOptions _tokenOptions;
        public TokenHandler(IOptions<CustomTokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SignHandler.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims:GetClaims(user),
                signingCredentials:signingCredentials

                );
            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken=CreateRefreshToken();
            accessToken.Expiration=accessTokenExpiration;
            return accessToken;
        }

        public void RevokeRefreshToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
