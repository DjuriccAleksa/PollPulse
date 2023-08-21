using MediatR;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;
using PollPulse.Entities.Models;

namespace PollPulse.CommandsAndQueries.Notifications
{
    public record UserRegisteredEvent(string URL, string Email, string Content) : INotification;
}
