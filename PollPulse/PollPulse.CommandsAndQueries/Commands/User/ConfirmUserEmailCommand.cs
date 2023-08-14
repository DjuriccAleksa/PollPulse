using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Interfaces;

namespace PollPulse.CommandsAndQueries.Commands.User
{
    public record ConfirmUserEmailCommand(string token, string username) : ICommand<IdentityResult>;
}
