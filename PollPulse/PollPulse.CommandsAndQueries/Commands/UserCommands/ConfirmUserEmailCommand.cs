using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Interfaces;

namespace PollPulse.CommandsAndQueries.Commands.UserCommands
{
    public record ConfirmUserEmailCommand(string Token, Guid Guid) : ICommand<IdentityResult>;
}
