using AutoMapper;
using PollPulse.CommandsAndQueries.Commands.SurveyResponseCommands;
using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO.QuestionResponsesDTOs;
using PollPulse.Entities.Models;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Handlers.SurveyResponseCommandsHandlers
{
    public class SubmitNewSurveyResponseCommandHandler : ICommandHandler<SubmitNewSurveyResponseCommand>
    {
        private readonly IUnitOfWorkRepository _repository;
        private readonly IMapper _mapper;
       
        public SubmitNewSurveyResponseCommandHandler(IUnitOfWorkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(SubmitNewSurveyResponseCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _repository.BeginTransaction();
            try
            {
                var surveyResponse = _mapper.Map<SurveyResponse>(request.SurveyResponseCreate);
                surveyResponse.SurveyId = request.SurveyId;

                _repository.SurveyResponseRepository.SubmitNewResponse(surveyResponse);
                await _repository.Save();

                var questionResponses = _mapper.Map<List<QuestionResponse>>(request.SurveyResponseCreate.QuestionResponses);

                foreach(var questionResponse in questionResponses)
                {
                    questionResponse.SurveyResponseId = surveyResponse.Id;
                    questionResponse.SurveyId = request.SurveyId;

                    foreach (var selectedOption in questionResponse.SelectedOptions)
                    {
                        selectedOption.SurveyId = request.SurveyId;
                        selectedOption.QuestionId = questionResponse.QuestionId;
                        selectedOption.SurveyResponseId = surveyResponse.Id;
                    }
                }

                surveyResponse.QuestionResponses = questionResponses;

                await _repository.Save();
                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }


        }
    }
}
