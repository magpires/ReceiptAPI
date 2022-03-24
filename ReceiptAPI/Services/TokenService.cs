using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReceiptAPI.Dtos.Response;
using ReceiptAPI.Entities;
using ReceiptAPI.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReceiptAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public TokenDto GenerateToken(User user)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenSettings:Secret").Value);
            var expires = Convert.ToInt32(_configuration.GetSection("TokenSettings:ExpiresTokenInHours").Value);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                }),

                Expires = DateTime.UtcNow.AddHours(expires),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var securityToken = tokenHandle.CreateToken(tokenDescription);
            var token = tokenHandle.WriteToken(securityToken);
            var expirationDate = tokenDescription.Expires.Value;

            return new TokenDto
            {
                Token = token,
                ExpirationDate = expirationDate,
            };
        }
    }
}
