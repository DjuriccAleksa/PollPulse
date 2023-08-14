using MediatR;
using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Interfaces;
using UserEntity = PollPulse.Entities.Models.User;
using PollPulse.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.User
{
    public record RegisterUserCommand(UserRegisterDTO user) : ICommand<(IdentityResult registerResult, UserEntity user)>;
}
