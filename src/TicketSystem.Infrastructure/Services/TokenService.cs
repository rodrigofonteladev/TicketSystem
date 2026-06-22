using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using TicketSystem.Application.DTOs.Auth;
using TicketSystem.Application.Interfaces.Services;

namespace TicketSystem.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserTokenDataDTO userData)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Dictionary<string, object>
            {
                { JwtRegisteredClaimNames.Sub, userData.UserId },
                { JwtRegisteredClaimNames.UniqueName, userData.UserName },
                { JwtRegisteredClaimNames.Email, userData.Email },
                { "role", userData.Roles }
            };

            var jwtDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials
            };

            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(jwtDescriptor);
            return token;
        }
    }
}