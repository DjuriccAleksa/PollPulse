using MediatR;
using PollPulse.CommandsAndQueries.Notifications;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System.Web;
using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;
using System.Reflection;
using PollPulse.Common.DTO;
using System.Net.Mail;
using System.Net;

namespace PollPulse.CommandsAndQueries.Handlers.Notifications
{
    public record SendEmailConfirmationHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly SmtpConfiguration _smptConfiguration;

        public SendEmailConfirmationHandler(IUnitOfWorkRepository repository, IOptions<SmtpConfiguration> configuration)
        {
            _repository = repository;
            _smptConfiguration = configuration.Value;
        }
        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var userForDb = await _repository.UserRepository.GetUserById(notification.id);

            var token = await _repository.UserRepository.GenerateTokenForEmailConfirmation(userForDb);

            var baseUrl = _smptConfiguration.BaseUrl;
            var confirmationLink = $"{baseUrl}/users/emailconfirmation/?token={HttpUtility.UrlEncode(token)}&guid={userForDb.Guid}";

            var assemblyWithEmailText = Assembly.GetAssembly(typeof(UserRegisterDTO));
            var fileName = "PollPulse.Common.Resources.EmailHtmlText.txt";

            using var stream = assemblyWithEmailText.GetManifestResourceStream(fileName);
            using var reader = new StreamReader(stream);
            var emailContent = await reader.ReadToEndAsync();

            emailContent = emailContent.Replace("ConfirmationLinkPlaceholder", confirmationLink);

            var clien = new SmtpClient(_smptConfiguration.Server, _smptConfiguration.Port)
            {
                Credentials = new NetworkCredential(_smptConfiguration.Email, _smptConfiguration.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(_smptConfiguration.Email!, _smptConfiguration.Username!),
                Subject = "PollPulse - Complete your registration",
                Body = emailContent,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(new MailAddress(userForDb.Email!));
            clien.Send(mailMessage);
        }
    }
}
