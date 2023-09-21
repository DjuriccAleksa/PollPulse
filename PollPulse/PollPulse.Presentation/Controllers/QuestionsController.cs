using MediatR;
using Microsoft.AspNetCore.Mvc;
using PollPulse.Application.Queries.QuestionQueries;
using PollPulse.Application.Queries.SurveyQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Presentation.Controllers
{
    [ApiController]
    [Route("api/surveys/{surveyGuid}/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly ISender _sender;

        public QuestionsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionResponsesForQuestion(Guid surveyGuid, long id)
        {
            var surveyId = await _sender.Send(new GetSurveyIdFromSurveyGuidQuery(surveyGuid)); 

            var question = await _sender.Send(new GetQuestionWithQuestionResponsesQuery(surveyId,id));

            return Ok(question);    
        }

    }
}
