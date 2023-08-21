using Microsoft.AspNetCore.Identity;
using PollPulse.CommandsAndQueries.Commands.UserCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Entities.Exceptions;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.UserCommandsHandlers
{
    public class ResetUserPasswordCommandHandler : ICommandHandler<ResetUserPasswordCommand, IdentityResult>
    {
        private readonly IUnitOfWorkRepository _repository;

        public ResetUserPasswordCommandHandler(IUnitOfWorkRepository repository)
        {
            _repository = repository;
        }

        public async Task<IdentityResult> Handle(ResetUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.UserRepository.GetUserByGuid(request.Guid);
            if (user is null)
                throw new UserNotFoundException(request.Guid);

            var resetPasswordResult = await _repository.UserRepository.ResetPassword(user, request.Token, request.Password);

            return resetPasswordResult;

        }
    }
}
