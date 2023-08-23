using Microsoft.AspNetCore.Identity;
using PollPulse.Application.Interfaces;

namespace PollPulse.Application.Commands.UserCommands
{
    public record ConfirmUserEmailCommand(string Token, Guid Guid) : ICommand<IdentityResult>;
}
