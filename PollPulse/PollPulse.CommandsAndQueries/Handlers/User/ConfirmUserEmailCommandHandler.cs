using MediatR;
using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Commands.User;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.User
{
    public sealed class ConfirmUserEmailCommandHandler : ICommandHandler<ConfirmUserEmailCommand, IdentityResult>
    {
        private readonly IUnitOfWorkRepository _repository;

        public ConfirmUserEmailCommandHandler(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _repository = unitOfWorkRepository;
        }

        public async Task<IdentityResult> Handle(ConfirmUserEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.UserRepository.GetUserByUsername(request.username);

            if (user is null)
                throw new Exception($"User with {request.username} is not found.");

            var result = await _repository.UserRepository.ConfirmUserEmail(user, request.token);
            return result;
        }
    }
}
