using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Queries.SurveyQueries
{
    public record GetSurveyForPatchQuery(Guid UserGuid, Guid SurveyGuid) : IQuery<(SurveyUpdateDTO surveyDto, Survey survey)>;
}
