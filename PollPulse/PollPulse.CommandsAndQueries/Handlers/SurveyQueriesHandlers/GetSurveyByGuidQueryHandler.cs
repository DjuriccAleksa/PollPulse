using AutoMapper;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.CommandsAndQueries.Queries.SurveyQueries;
using PollPulse.Common.DTO;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyQueriesHandlers
{
    public sealed class GetSurveyByGuidQueryHandler : IQueryHandler<GetSurveyByGuidQuery, SurveyDTO>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;
        public GetSurveyByGuidQueryHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SurveyDTO> Handle(GetSurveyByGuidQuery request, CancellationToken cancellationToken)
        {
            var userFromDb = await _repository.UserRepository.GetUserByGuid(request.UserGuid);
            if (userFromDb is null)
                throw new Exception("User is not found");

            var surveyFromDb = await _repository.SurveyRepository.GetByGuid(request.UserGuid, request.SurveyGuid);
            if (surveyFromDb is null)
                throw new Exception("Survey is not found");

            var surveyToReturn = _mapper.Map<SurveyDTO>(surveyFromDb);

            return surveyToReturn;
        }
    }
}
