using MediatR;
using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.UserCommands
{
    public record RegisterUserCommand(UserRegisterDTO user) : ICommand<(IdentityResult registerResult, User user)>;
}
