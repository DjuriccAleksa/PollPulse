using AutoMapper;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Queries.QuestionQueries;
using PollPulse.Common.DTO.QuestionsDTOs;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.QuestionQueriesHandlers
{
    public class GetQuestionWithQuestionResponsesQueryHandler : IQueryHandler<GetQuestionWithQuestionResponsesQuery, QuestionDTO>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public GetQuestionWithQuestionResponsesQueryHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QuestionDTO> Handle(GetQuestionWithQuestionResponsesQuery request, CancellationToken cancellationToken)
        {
           var questionFromDb = await _repository.QuestionRepository.GetQuestionWithResponses(request.SurveyId, request.QuestionId);

           var questionToReturn = _mapper.Map<QuestionDTO>(questionFromDb);

            return questionToReturn;
        }
    }
}
