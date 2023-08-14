using AutoMapper;
using MediatR;
using PollPulse.CommandsAndQueries.Notifications;
using PollPulse.Repository.Interfaces.Unit_of_work;
using UserEntity = PollPulse.Entities.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;
using System.Reflection;
using PollPulse.Common.DTO;

namespace PollPulse.CommandsAndQueries.Handlers.Notifications
{
    public record SendEmailConfirmationHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly SendGridConfiguration _configuration;
        private readonly ISendGridClient _sendGrid;

        public SendEmailConfirmationHandler(IUnitOfWorkRepository repository, IOptions<SendGridConfiguration> configuration, ISendGridClient sendGrid)
        {
            _repository = repository;
            _configuration = configuration.Value;
            _sendGrid = sendGrid;
        }
        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var userForDb = await _repository.UserRepository.GetUserById(notification.id);

            var token = await _repository.UserRepository.GenerateTokenForEmailConfirmation(userForDb);

            var baseUrl = _configuration.BaseUrl;
            var confirmationLink = $"{baseUrl}/users/emailconfirmation/?token={HttpUtility.UrlEncode(token)}&username={userForDb.UserName}";

            var from = new EmailAddress(_configuration.FromEmail, _configuration.FromName);
            var to = new EmailAddress(userForDb.Email);

            var assemblyWithEmailText = Assembly.GetAssembly(typeof(UserRegisterDTO));
            var fileName = "PollPulse.Common.Resources.EmailHtmlText.txt";

            using var stream = assemblyWithEmailText.GetManifestResourceStream(fileName);
            using var reader = new StreamReader(stream);
            var emailContent = await reader.ReadToEndAsync();

            emailContent = emailContent.Replace("ConfirmationLinkPlaceholder", confirmationLink);

            var msg = MailHelper.CreateSingleEmail(from, to, "PollPulse - Complete your registration", emailContent, emailContent);

            var res = await _sendGrid.SendEmailAsync(msg, cancellationToken);

        }
    }
}
