using MediatR;
using Microsoft.AspNetCore.Identity;
using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Interfaces;
using PollPulse.Entities.Exceptions;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
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
            var user = await _repository.UserRepository.GetUserByGuid(request.Guid);

            if (user is null)
                throw new UserNotFoundException(request.Guid);

            var result = await _repository.UserRepository.ConfirmUserEmail(user, request.Token);
            return result;
        }
    }
}
