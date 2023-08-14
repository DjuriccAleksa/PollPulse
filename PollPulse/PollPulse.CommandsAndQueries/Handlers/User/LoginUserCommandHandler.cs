﻿using AutoMapper;
using PollPulse.CommandsAndQueries.Commands.User;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;

namespace PollPulse.CommandsAndQueries.Handlers.User
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, (bool Success, string Message)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<(bool Success, string Message)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.UserRepository.LoginUser(request.user.Username, request.user.Password);

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

            return (result.Succeeded, message);
        }
    }
}