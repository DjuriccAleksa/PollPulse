using MediatR;

namespace PollPulse.CommandsAndQueries.Notifications;

public record UserForgotPasswordEvent(string URL, string Email, string Content) : INotification;
