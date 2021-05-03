using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Weatherex.Application.Interfaces;

namespace Weatherex.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwtToken(string userId)
        {
            var tokenClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenIssuer = _configuration["Jwt:Issuer"];
            var tokenAudience = _configuration["Jwt:Audience"];
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var tokenCreds = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
            var tokenExpires = DateTime.Now.AddMinutes(60);

            var token = new JwtSecurityToken(
                issuer: tokenIssuer,
                audience: tokenAudience,
                signingCredentials: tokenCreds,
                claims: tokenClaims,
                expires: tokenExpires
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
