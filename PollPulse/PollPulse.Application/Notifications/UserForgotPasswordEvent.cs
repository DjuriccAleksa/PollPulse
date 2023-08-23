using MediatR;

namespace PollPulse.Application.Notifications;

public record UserForgotPasswordEvent(string Email, string ResetLink) : INotification;
