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
    internal class GetAllSurveysForUserQueryHandler : IQueryHandler<GetAllSurveysForUserQuery, IEnumerable<SurveyDTO>>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSurveysForUserQueryHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SurveyDTO>> Handle(GetAllSurveysForUserQuery request, CancellationToken cancellationToken)
        {
            var user = await  _repository.UserRepository.GetUserByGuid(request.Guid);
            if (user is null)
                throw new Exception("User is not found");

            var surveysFromDb = await  _repository.SurveyRepository.GetAllSurveysForUser(request.Guid);

            var surveysToRetrun = _mapper.Map<IEnumerable<SurveyDTO>>(surveysFromDb);

            return surveysToRetrun;
        }
    }
}
