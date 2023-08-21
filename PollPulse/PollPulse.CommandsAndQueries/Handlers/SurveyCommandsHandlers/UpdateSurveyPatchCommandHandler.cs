﻿using AutoMapper;
using PollPulse.CommandsAndQueries.Commands.SurveyCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyCommandsHandlers
{
    public class UpdateSurveyPatchCommandHandler : ICommandHandler<UpdateSurveyPatchCommand>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSurveyPatchCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSurveyPatchCommand request, CancellationToken cancellationToken)
        {
            _mapper.Map(request.SurveyUpdateDTO, request.Survey);
            await _repository.Save();
        }
    }
}
