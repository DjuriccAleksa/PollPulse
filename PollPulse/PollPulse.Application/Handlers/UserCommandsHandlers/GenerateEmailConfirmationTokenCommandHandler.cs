using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Notifications;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Entities.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MediatR;
using PollPulse.Repository.Interfaces.Unit_of_work;
using Microsoft.Extensions.Configuration;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
{
    public class GenerateEmailConfirmationTokenCommandHandler : ICommandHandler<GenerateEmailConfirmationTokenCommand, string>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IConfiguration _configuration;

        public GenerateEmailConfirmationTokenCommandHandler(IUnitOfWorkRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Handle(GenerateEmailConfirmationTokenCommand request, CancellationToken cancellationToken)
        {
            if (request.User is null)
                throw new Exception("You have to pass user first");

            var token = await _repository.UserRepository.GenerateTokenForEmailConfirmation(request.User);

            var baseUrl = _configuration.GetSection("BaseUrl").Value;

            var confirmationLink = $"{baseUrl}/users/emailconfirmation/?token={HttpUtility.UrlEncode(token)}&guid={request.User.Guid}";

            return confirmationLink;
        }


    }
}
