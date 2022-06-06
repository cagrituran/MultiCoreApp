﻿namespace MultiCoreApp.API.Security
{
    public class CustomTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
