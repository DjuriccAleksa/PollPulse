using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PollPulse.CommandsAndQueries.Commands.SurveyCommands;
using PollPulse.CommandsAndQueries.Queries.SurveyQueries;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.RequestFeatrues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PollPulse.Presentation.Controllers
{
    [Route("api/users/{userGuid}/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISender _sender;

        public SurveysController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveysForUser(Guid userGuid, [FromQuery] SurveySpecification surveySpecification)
        {
            var surveys = await _sender.Send(new GetAllSurveysForUserQuery(userGuid, surveySpecification));

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(surveys.PaginationData));

            return Ok(surveys.Surveys);
        }

        [HttpGet("{surveyGuid:guid}", Name = "GetSurveyByGuid")]
        public async Task<IActionResult> GetSurveyByGuid(Guid userGuid, Guid surveyGuid)
        {
            var survey = await _sender.Send(new GetSurveyByGuidQuery(userGuid, surveyGuid));

            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSurvey(Guid userGuid, [FromBody] SurveyCreateDTO surveyCreate)
        {
            if (surveyCreate is null)
                return BadRequest("Survey create is null");

            var surveyCreated = await _sender.Send(new CreateSurveyCommand(userGuid, surveyCreate));

            return CreatedAtRoute("GetSurveyByGuid", new { userGuid, surveyGuid = surveyCreated.Guid }, surveyCreated);
        }

        [HttpPatch("{surveyGuid:guid}")]
        public async Task<IActionResult> UpdateSurveyDateFinished(Guid userGuid, Guid surveyGuid, [FromBody] JsonPatchDocument<SurveyUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("Patch doc is null");

            var surveys = await _sender.Send(new GetSurveyForPatchQuery(userGuid, surveyGuid));

            patchDoc.ApplyTo(surveys.surveyDto);

            await _sender.Send(new UpdateSurveyPatchCommand(surveys.surveyDto, surveys.survey));

            return NoContent();
        }

        [HttpDelete("{surveyGuid:guid}")]
        public async Task<IActionResult> DeleteSurvey(Guid userGuid, Guid surveyGuid)
        {
            await _sender.Send(new DeleteSurveyCommand(userGuid, surveyGuid));

            return NoContent();
        }
    }
}
