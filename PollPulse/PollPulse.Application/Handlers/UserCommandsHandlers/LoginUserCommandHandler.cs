using AutoMapper;
using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Interfaces;
using PollPulse.Entities.Models;
using PollPulse.Repository.Interfaces.Unit_of_work;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, (User? User , string Message)>
    {
        private readonly IUnitOfWorkRepository _repository;

        public LoginUserCommandHandler(IUnitOfWorkRepository repository)
        {
            _repository = repository;
           
        }
        public async Task<(User? User, string Message)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.UserRepository.LoginUser(request.User.Username, request.User.    Password);

            string message = "";

            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                    message = "Please confirm your email address to login.";
                else if (result.IsLockedOut)
                    message = "You tried to log in so many times. You are locked out.";
                else
                    message = "Incorect username or password.";
            }

            var user = await _repository.UserRepository.GetUserByUsername(request.User.Username);

            return (User: user, Message: message);
        }
    }
}
