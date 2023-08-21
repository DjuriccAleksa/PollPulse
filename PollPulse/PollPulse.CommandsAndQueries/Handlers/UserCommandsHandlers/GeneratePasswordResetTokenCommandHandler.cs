using Microsoft.Extensions.Configuration;
using PollPulse.CommandsAndQueries.Commands.UserCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PollPulse.CommandsAndQueries.Handlers.UserCommandsHandlers
{
    public class GeneratePasswordResetTokenCommandHandler : ICommandHandler<GeneratePasswordResetTokenCommand, string>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IConfiguration _configuration;

        public GeneratePasswordResetTokenCommandHandler(IUnitOfWorkRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Handle(GeneratePasswordResetTokenCommand request, CancellationToken cancellationToken)
        {
            var userFromDb = await _repository.UserRepository.GetUserByEmail(request.Email);
            if (userFromDb is null)
                return "";

            var token = await _repository.UserRepository.GenerateTokenForPasswordResest(userFromDb);

            var baseUrl = _configuration.GetSection("BaseUrl").Value;

            var confirmationLink = $"{baseUrl}/users/password-reset/?token={token}&guid={userFromDb.Guid}";

            return confirmationLink;
        }
    }
}
