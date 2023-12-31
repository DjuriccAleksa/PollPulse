﻿using AutoMapper;
using PollPulse.Application.Interfaces;
using PollPulse.Application.Queries.SurveyQueries;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Entities.Exceptions;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Handlers.SurveyQueriesHandlers
{
    public class GetAllSurveysForUserQueryHandler : IQueryHandler<GetAllSurveysForUserQuery, (IEnumerable<SurveyDTO> Surveys, PaginationData PaginationData)>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSurveysForUserQueryHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<SurveyDTO> Surveys, PaginationData PaginationData)> Handle(GetAllSurveysForUserQuery request, CancellationToken cancellationToken)
        {
            var user = await  _repository.UserRepository.GetUserByGuid(request.Guid);
            if (user is null)
                throw new UserNotFoundException(request.Guid);

            var surveysFromDb = await  _repository.SurveyRepository.GetAllSurveysForUser(request.Guid, request.SurveySpecification);
            var surveysToRetrun = _mapper.Map<List<SurveyDTO>>(surveysFromDb);

            return (Surveys: surveysToRetrun, PaginationData: surveysFromDb.PaginationData);
        }
    }
}
