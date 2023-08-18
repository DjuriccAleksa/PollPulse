using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.UserCommands
{
    public record GeneratePasswordResetTokenCommand(string Email) : ICommand<string>;
}
