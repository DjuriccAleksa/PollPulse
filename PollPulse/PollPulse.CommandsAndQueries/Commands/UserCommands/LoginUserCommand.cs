using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO.UsersDTOs;

namespace PollPulse.CommandsAndQueries.Commands.UserCommands
{
    public record LoginUserCommand(UserLoginDTO User) : ICommand<(bool, string)>; 
}
