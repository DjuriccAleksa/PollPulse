using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.CommandsAndQueries.Queries.SurveyResponseQueries;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyResponseQueriesHandlers
{
    public class GetAllSurveyResponsesForSurveyQueryHandler : IQueryHandler<GetAllSurveyResponsesForSurveyQuery, (IEnumerable<SurveyResponseDTO> surveyResponses, PaginationData paginationData)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSurveyResponsesForSurveyQueryHandler(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
        {
            _repository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<SurveyResponseDTO> surveyResponses, PaginationData paginationData)> Handle(GetAllSurveyResponsesForSurveyQuery request, CancellationToken cancellationToken)
        {
            var surveyId = await _repository.SurveyRepository.GetSurveyId(request.Guid); 
            
            var surveyResponsesFromDb = await _repository.SurveyResponseRepository.GetSurveyResponsesForSurvey(surveyId, request.SurveyResponseSpecification);

            var surveysToReturn = _mapper.Map<List<SurveyResponseDTO>>(surveyResponsesFromDb);

            return (surveysToReturn, surveyResponsesFromDb.PaginationData);
        }
    }
}
