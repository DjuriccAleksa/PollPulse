using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;

namespace PollPulse.API.OptionsSetup
{
    public class SmtpConfigurationSetup : IConfigureOptions<SmtpConfiguration>
    {
        private const string SectionName = "SmtpSettings";
        private readonly IConfiguration _configuration;

        public SmtpConfigurationSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(SmtpConfiguration options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
