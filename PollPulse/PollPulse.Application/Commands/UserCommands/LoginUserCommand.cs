using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Entities.Models;

namespace PollPulse.Application.Commands.UserCommands
{
    public record LoginUserCommand(UserLoginDTO User) : ICommand<(User?, string)>; 
}
