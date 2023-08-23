using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using PollPulse.Application.Interfaces.Services;
using PollPulse.Entities.EmailModel;
using PollPulse.Entities.Options;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly SmtpConfiguration _smtpConfiguration;
        private readonly IConfiguration _coniguration;
        public EmailService(IOptions<SmtpConfiguration> options )
        {
            _smtpConfiguration = options.Value;
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            _coniguration = configurationBuilder.Build();
        }

        public async Task SendEmail<TModel>(EmailData emailData, string fileTemplateName, TModel model)
        {
            try
            {
                using MimeMessage emailMessage = new MimeMessage();
                var emailFrom = new MailboxAddress(_smtpConfiguration.Username, _smtpConfiguration.Email);
                var emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToEmail);

                emailMessage.From.Add(emailFrom);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailToSubject;



                var templatesPath = _coniguration["TemplatesURL"];

                string templatePath = Path.Combine(templatesPath, fileTemplateName);

                string emailTemplateText = await File.ReadAllTextAsync(templatePath);

                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(typeof(EmailService).Assembly)
                    .UseMemoryCachingProvider()
                    .Build();

                

                var emailBody = await engine.CompileRenderStringAsync(templatePath, emailTemplateText, model);

                var bodyBuilder = new BodyBuilder()
                {
                    HtmlBody = emailBody,
                    TextBody = emailBody,
                };

                emailMessage.Body = bodyBuilder.ToMessageBody();

                using var mailClient = new SmtpClient();
                mailClient.Connect(_smtpConfiguration.Server, _smtpConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);
                mailClient.Authenticate(_smtpConfiguration.Email, _smtpConfiguration.Password);
                await mailClient.SendAsync(emailMessage);
                mailClient.Disconnect(true);

             }
            catch ( Exception ex)
            {

                throw ex;
            }
        }
    }
}
