﻿using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PollPulse.Entities.Models;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, (IdentityResult registerResult, User user)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IdentityResult registerResult, User user)> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.User);
            user.Guid = Guid.NewGuid();

            var registerResult = await _repository.UserRepository.RegisterUser(user, request.User.Password);
            
            return (registerResult, user);
        }
    }
}
