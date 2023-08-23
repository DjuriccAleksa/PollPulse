using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;

namespace PollPulse.API.OptionsSetup;

public class JwtConfigurationSetup : IConfigureOptions<JwtConfiguration>
{
    private const string SectionName = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtConfigurationSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtConfiguration options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}
