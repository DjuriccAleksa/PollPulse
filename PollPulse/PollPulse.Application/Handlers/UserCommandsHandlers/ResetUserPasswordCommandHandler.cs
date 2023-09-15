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
using System.Web;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
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
            var user = await _repository.UserRepository.GetUserByGuid(Guid.Parse(request.User.Guid));
            if (user is null)
                throw new UserNotFoundException(Guid.Parse(request.User.Guid));


            var resetPasswordResult = await _repository.UserRepository.ResetPassword(user, request.User.Token, request.User.Password);

            return resetPasswordResult;

        }
    }
}
