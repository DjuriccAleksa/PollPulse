using MediatR;
using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;
using System.Reflection;
using System.Net.Mail;
using System.Net;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Notifications;
using PollPulse.Application.Interfaces.Services;
using PollPulse.Entities.EmailModel;

namespace PollPulse.Application.Handlers.Notifications;

public record SendEmailOnUserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    private readonly IEmailService _emailService;

    public SendEmailOnUserRegisteredEventHandler(IEmailService emailService) => _emailService = emailService;

    public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        var emailData = new EmailData()
        {
            EmailToEmail = notification.Email,
            EmailToName = notification.Name,
            EmailToSubject = "PollPulse - Complete your registration"
        };

        var templateName = "RegistrationEmailTemplate.cshtml";

        await _emailService.SendEmail<string>(emailData, templateName, notification.ConfirmationLink);
    }

}
