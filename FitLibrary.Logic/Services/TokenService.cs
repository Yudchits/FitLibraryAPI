using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitLibrary.Logic.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserBLL user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                authClaims.Add(new Claim("role", role.Name));
            }

            var isInt = int.TryParse(_configuration["TOKEN_EXPIRES_SECONDS"], out int tokenExpiresSeconds);

            tokenExpiresSeconds = isInt ? tokenExpiresSeconds : 3600;

            var token = new JwtSecurityToken(
                issuer: _configuration["ISSUER"],
                audience: _configuration["AUDIENCE"],
                expires: DateTime.Now.AddSeconds(tokenExpiresSeconds),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JWT_SECRET"])
                    ),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}