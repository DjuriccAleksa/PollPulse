using MediatR;
using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO;
using PollPulse.Entities.Models;

namespace PollPulse.Application.Notifications
{
    public record UserRegisteredEvent(string Email, string Name, string ConfirmationLink) : INotification;
}
