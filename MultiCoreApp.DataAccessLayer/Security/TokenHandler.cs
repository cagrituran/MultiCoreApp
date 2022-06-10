﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using MultiCoreApp.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MultiCoreApp.DataAccessLayer.Security
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
                notBefore: DateTime.Now.AddMilliseconds(-50),
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
        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }
        }
        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,$"{user.Name} {user.SurName}"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())


            };
            return claims;
        }
        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken=null;
        }
    }
}
