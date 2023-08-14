using MediatR;
using PollPulse.CommandsAndQueries.Commands.User;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using UserEntity = PollPulse.Entities.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace PollPulse.CommandsAndQueries.Handlers.User
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, (IdentityResult registerResult, UserEntity user)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IdentityResult registerResult, UserEntity user)> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request.user);

            var registerResult = await _repository.UserRepository.RegisterUser(user, request.user.Password);

            return (registerResult, user);
        }
    }
}
