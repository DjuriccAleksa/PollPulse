using AutoMapper;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Queries.SurveyQueries;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Entities.Exceptions;
using PollPulse.Entities.Models;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.SurveyQueriesHandlers
{
    public class GetSurveyForPatchQueryHandler : IQueryHandler<GetSurveyForPatchQuery, (SurveyUpdateDTO surveyDto, Survey survey)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public GetSurveyForPatchQueryHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(SurveyUpdateDTO surveyDto, Survey survey)> Handle(GetSurveyForPatchQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.UserRepository.GetUserByGuid(request.UserGuid);
            if (user is null)
                throw new UserNotFoundException(request.UserGuid);

            var surveyFromDb = await _repository.SurveyRepository.GetByGuid(request.UserGuid, request.SurveyGuid);
            if (surveyFromDb is null)
                throw new SurveyNotFoundException(request.SurveyGuid);

            var surveyDto = _mapper.Map<SurveyUpdateDTO>(surveyFromDb);

            return (surveyDto: surveyDto, survey: surveyFromDb);
        }
    }
}
