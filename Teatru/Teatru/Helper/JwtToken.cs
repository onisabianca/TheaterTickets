using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatru.Helper
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.UtcNow.AddMinutes(1);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"sub", "Teatru" },
                {"Name", "Bianca" },
                {"email", "bia@yahoo.com" },
                {"exp", ts },
                {"iss", "https://localhost:44368" },
                {"aud", "https://localhost:44368" }
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            Console.WriteLine(tokenString);

            return tokenString;
        }
    }
}
