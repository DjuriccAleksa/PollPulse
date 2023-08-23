using PollPulse.Application.Commands.UserCommands;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.UserCommandsHandlers
{
    public class GenerateNewJwtTokenCommandHandler : ICommandHandler<GenerateNewJwtTokenCommand, string>
    {
        private readonly IJwtProviderService _jwtProvider;

        public GenerateNewJwtTokenCommandHandler(IJwtProviderService jwtProvider)
        {
            _jwtProvider = jwtProvider;
        }

        public Task<string> Handle(GenerateNewJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _jwtProvider.GenerateJwtToken(request.User);
            return Task.FromResult(token);
        }
    }
}
