using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PollPulse.API.OptionsSetup
{
    public class JwtBearerConfigurationSetup : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public JwtBearerConfigurationSetup(IOptions<JwtConfiguration> jwtConfiguration) => _jwtConfiguration = jwtConfiguration.Value;

        public void Configure(string? name, JwtBearerOptions options) => Configure(options);

        public void Configure(JwtBearerOptions options)
        {
            var key = Environment.GetEnvironmentVariable("PollPulseSecurityKey");
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = _jwtConfiguration.Issuer,
                ValidAudience = _jwtConfiguration.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        }
    }
}
