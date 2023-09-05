using Microsoft.Extensions.Options;

namespace PollPulse.Web.OptionsSetup.ApplicationOptions
{
    public class ApplicationConfigSetup : IConfigureOptions<ApplicationConfiguration>
    {
        private const string SectionName = "AppParameteres";
        private readonly IConfiguration _configuration;

        public ApplicationConfigSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(ApplicationConfiguration options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
