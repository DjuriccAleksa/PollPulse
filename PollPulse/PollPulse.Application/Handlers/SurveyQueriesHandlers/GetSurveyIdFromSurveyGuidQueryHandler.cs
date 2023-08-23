using PollPulse.Application.Interfaces;
using PollPulse.Application.Queries.SurveyQueries;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.SurveyQueriesHandlers
{
    public class GetSurveyIdFromSurveyGuidQueryHandler : IQueryHandler<GetSurveyIdFromSurveyGuidQuery, long>
    {
        private readonly IUnitOfWorkRepository _repository;

        public GetSurveyIdFromSurveyGuidQueryHandler(IUnitOfWorkRepository repository)
        {
            _repository = repository;
        }

        public Task<long> Handle(GetSurveyIdFromSurveyGuidQuery request, CancellationToken cancellationToken)
        {
            var id = _repository.SurveyRepository.GetSurveyId(request.SurveyGuid);
            return id;
        }
    }
}
