using MediatR;
using Microsoft.Extensions.Options;
using PollPulse.Entities.Options;
using System.Reflection;
using System.Net.Mail;
using System.Net;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.CommandsAndQueries.Notifications;

namespace PollPulse.CommandsAndQueries.Handlers.Notifications;

public record SendEmailWithTokenLinkHandler : INotificationHandler<UserRegisteredEvent>, INotificationHandler<UserForgotPasswordEvent>
{
    private readonly SmtpConfiguration _smptConfiguration;

    public SendEmailWithTokenLinkHandler(IOptions<SmtpConfiguration> configuration) => _smptConfiguration = configuration.Value;

    private async Task SendEmailWithTokenLink(string URL, string Email, string Content)
    {
        var assemblyWithEmailText = Assembly.GetAssembly(typeof(UserRegisterDTO));
        var fileName = $"PollPulse.Common.Resources.{Content}";

        using var stream = assemblyWithEmailText.GetManifestResourceStream(fileName);
        using var reader = new StreamReader(stream);
        var emailContent = await reader.ReadToEndAsync();

        emailContent = emailContent.Replace("ConfirmationLinkPlaceholder", URL);

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

        mailMessage.To.Add(new MailAddress(Email));
        clien.Send(mailMessage);
    }


    public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        await SendEmailWithTokenLink(notification.URL, notification.Email, notification.Content);
    }

    public async Task Handle(UserForgotPasswordEvent notification, CancellationToken cancellationToken)
    {
        await SendEmailWithTokenLink(notification.URL, notification.Email, notification.Content);
    }
}
