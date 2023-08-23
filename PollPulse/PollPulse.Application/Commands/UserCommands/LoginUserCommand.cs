using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.UsersDTOs;

namespace PollPulse.Application.Commands.UserCommands
{
    public record LoginUserCommand(UserLoginDTO User) : ICommand<(bool, string)>; 
}
