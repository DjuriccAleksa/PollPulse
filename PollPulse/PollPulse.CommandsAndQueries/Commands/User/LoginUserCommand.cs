using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;

namespace PollPulse.CommandsAndQueries.Commands.User
{
    public record LoginUserCommand(UserLoginDTO user) : ICommand<(bool, string)>; 
}
