﻿using PollPulse.CommandsAndQueries.Commands.SurveyCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyCommandsHandlers
{
    public class DeleteSurveyCommandHandler : ICommandHandler<DeleteSurveyCommand>
    {
        private readonly IUnitOfWorkRepository _repostiory;

        public DeleteSurveyCommandHandler(IUnitOfWorkRepository repostiory)
        {
            _repostiory = repostiory;
        }

        public async Task Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var userFromDb = await _repostiory.UserRepository.GetUserByGuid(request.UserGuid);
            if (userFromDb is null)
                throw new Exception("User is not found");

            var surveyFromDb = await _repostiory.SurveyRepository.GetByGuid(request.UserGuid, request.SurveyGuid);
            if (surveyFromDb is null)
                throw new Exception("Surve is not found");

            _repostiory.SurveyRepository.DeleteSurvey(surveyFromDb);
            await _repostiory.Save();


        }
    }
}
