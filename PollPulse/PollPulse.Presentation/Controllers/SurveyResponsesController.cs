using MediatR;
using Microsoft.AspNetCore.Mvc;
using PollPulse.CommandsAndQueries.Commands.SurveyResponseCommands;
using PollPulse.CommandsAndQueries.Queries.SurveyQueries;
using PollPulse.CommandsAndQueries.Queries.SurveyResponseQueries;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PollPulse.Presentation.Controllers
{
    [Route("api/surveys/{surveyGuid}/responses")]
    [ApiController]
    public class SurveyResponsesController : ControllerBase
    {
        private readonly ISender _sender;

        public SurveyResponsesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveyResponsesForSurvey(Guid surveyGuid, [FromQuery] SurveyResponseSpecification surveyResponseSpecification)
        {
            var surveyResponses = await _sender.Send(new GetAllSurveyResponsesForSurveyQuery(surveyGuid, surveyResponseSpecification));

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(surveyResponses.paginationData));

            return Ok(surveyResponses.surveyResponses);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitNewResponse(Guid surveyGuid, [FromBody] SurveyResponseCreateDTO surveyResponse)
        {
            var surveyId = await _sender.Send(new GetSurveyIdFromSurveyGuidQuery(surveyGuid));
            await _sender.Send(new SubmitNewSurveyResponseCommand(surveyId, surveyResponse));

            return StatusCode(201);
        }
    }
}
