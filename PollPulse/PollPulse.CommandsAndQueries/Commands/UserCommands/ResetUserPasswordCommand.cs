using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.UserCommands
{
    public record ResetUserPasswordCommand(string Token, Guid Guid, string Password) : ICommand<IdentityResult>;
}
