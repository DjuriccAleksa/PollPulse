using MediatR;
using PollPulse.Application.Interfaces.Services;
using PollPulse.Application.Notifications;
using PollPulse.Entities.EmailModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.Notifications
{
    public class SendEmailOnUserForgotPasswordEventHandler : INotificationHandler<UserForgotPasswordEvent>
    {
        private readonly IEmailService _emailService;

        public SendEmailOnUserForgotPasswordEventHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(UserForgotPasswordEvent notification, CancellationToken cancellationToken)
        {
            var emailData = new EmailData
            {
                EmailToEmail = notification.Email,
                EmailToName = notification.Email,
                EmailToSubject = "PollPulse - Restart your password"
            };

            var templateName = "RestartPasswordEmailTemplate.cshtml";

            await _emailService.SendEmail<string>(emailData, templateName, notification.ResetLink);
        }
    }
}
