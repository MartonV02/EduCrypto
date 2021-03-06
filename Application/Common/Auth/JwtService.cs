using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Common.Auth
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _expDate;

        public JwtService(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public string GenerateSecurityToken(string email, int userId)
        {
            var key = Encoding.ASCII.GetBytes(_secret);
            var claims = new List<Claim>()
            {
                new Claim("email", email),
                new Claim("userId", userId.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = new JwtSecurityToken(
                issuer: "trader",
                audience: "federation",
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_expDate)),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );
            return tokenHandler.WriteToken(jwt);
        }
    }
}
