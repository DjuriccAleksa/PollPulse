using MediatR;
using PollPulse.Common.DTO;

namespace PollPulse.CommandsAndQueries.Notifications
{
    public record UserRegisteredEvent(Guid Guid) : INotification;
}
