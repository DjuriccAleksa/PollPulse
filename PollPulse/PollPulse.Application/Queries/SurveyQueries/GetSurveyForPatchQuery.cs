using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Queries.SurveyQueries
{
    public record GetSurveyForPatchQuery(Guid UserGuid, Guid SurveyGuid) : IQuery<(SurveyUpdateDTO surveyDto, Survey survey)>;
}
