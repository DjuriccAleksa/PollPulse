using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PollPulse.Application.Interfaces.Services;
using PollPulse.Entities.Models;
using PollPulse.Entities.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Services
{
    public sealed class JwtProviderService : IJwtProviderService
    {
        private User? _user;

        private readonly JwtConfiguration _jwtConfiguration;

        public JwtProviderService(IOptions<JwtConfiguration> jwtConfiguration) => _jwtConfiguration = jwtConfiguration.Value;

        public string GenerateJwtToken(User user)
        {
            _user = user;

            var signingCredentials = GetSigningCredentials();
            var claims = GetListOfClaims();

            var token = new JwtSecurityToken
            (
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.ExpirationTime)),
                signingCredentials: signingCredentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("PollPulseSecurityKey"));
            var securityKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            return signingCredentials;
        }

        private List<Claim> GetListOfClaims()
        {
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, _user.Guid.ToString()),
                new(JwtRegisteredClaimNames.Email, _user.Email),
                new(JwtRegisteredClaimNames.UniqueName, _user.UserName)
            };

            return claims;
        }
    }
}
