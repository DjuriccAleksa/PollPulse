using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PollPulse.Application.Commands.SurveyCommands;
using PollPulse.Application.Queries.SurveyQueries;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.RequestFeatrues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PollPulse.Presentation.Controllers
{
    [Route("api/surveys")]
    [ApiController]
    [Authorize]
    public class SurveysController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IHttpContextAccessor _contextAccessor;

        public SurveysController(ISender sender, IHttpContextAccessor contextAccessor)
        {
            _sender = sender;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveysForUser([FromQuery] SurveySpecification surveySpecification)
        {
            var userGuid = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var surveys = await _sender.Send(new GetAllSurveysForUserQuery(userGuid, surveySpecification));

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(surveys.PaginationData));

            return Ok(surveys.Surveys);
        }

        [HttpGet("{surveyGuid:guid}", Name = "GetSurveyByGuid")]
        public async Task<IActionResult> GetSurveyByGuid(Guid surveyGuid)
        {
            var userGuid = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var survey = await _sender.Send(new GetSurveyForUserByGuidQuery(userGuid, surveyGuid));

            return Ok(survey);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewSurvey( [FromBody] SurveyCreateDTO surveyCreate)
        {
            if (surveyCreate is null)
                return BadRequest("Survey create is null");


            var userGuid = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var surveyCreated = await _sender.Send(new CreateSurveyCommand(userGuid, surveyCreate));

            return CreatedAtRoute("GetSurveyByGuid", new { userGuid, surveyGuid = surveyCreated.Guid }, surveyCreated);
        }

        [HttpPatch("{surveyGuid:guid}")]
        public async Task<IActionResult> UpdateSurveyDateFinished(Guid surveyGuid, [FromBody] JsonPatchDocument<SurveyUpdateDTO> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("Patch doc is null");

            var userGuid = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var surveys = await _sender.Send(new GetSurveyForPatchQuery(userGuid, surveyGuid));

            patchDoc.ApplyTo(surveys.surveyDto);

            await _sender.Send(new UpdateSurveyPatchCommand(surveys.surveyDto, surveys.survey));

            return NoContent();
        }

        [HttpDelete("{surveyGuid:guid}")]
        public async Task<IActionResult> DeleteSurvey(Guid surveyGuid)
        {
            var userGuid = Guid.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _sender.Send(new DeleteSurveyCommand(userGuid, surveyGuid));

            return NoContent();
        }
    }
}
