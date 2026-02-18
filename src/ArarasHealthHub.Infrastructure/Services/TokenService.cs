using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Identity;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ArarasHealthHub.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;

            var signingKey = _config["JWT:SigningKey"]
                ?? throw new InvalidOperationException("JWT:SigningKey is not configured.");

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        }

        public string CreateToken(ApplicationUser account)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim(ClaimTypes.Name, account.UserName ?? string.Empty),
            new Claim("FacilityId", account.FacilityId.ToString()),
            new Claim("Scope", account.Scope.ToString()),
            new Claim(ClaimTypes.Role, account.Role.ToString())
        };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }
    }
}
