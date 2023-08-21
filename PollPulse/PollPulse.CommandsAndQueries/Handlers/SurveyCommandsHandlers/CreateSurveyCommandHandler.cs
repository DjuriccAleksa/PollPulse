using AutoMapper;
using PollPulse.CommandsAndQueries.Commands.SurveyCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Entities.Exceptions;
using PollPulse.Entities.Models;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyCommandsHandlers
{
    public sealed class CreateSurveyCommandHandler : ICommandHandler<CreateSurveyCommand, SurveyDTO>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;
        public CreateSurveyCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SurveyDTO> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var userFromDb = await _repository.UserRepository.GetUserByGuid(request.UserGuid);
            if (userFromDb is null)
                throw new UserNotFoundException(request.UserGuid);

            var survey = _mapper.Map<Survey>(request.Survey);
            survey.Guid = Guid.NewGuid();
            survey.UserId = userFromDb.Id;

            _repository.SurveyRepository.CreateSurvey(survey);
            await _repository.Save();

            var surveyToReturn = _mapper.Map<SurveyDTO>(survey);

            return surveyToReturn;
        }
    }
}
