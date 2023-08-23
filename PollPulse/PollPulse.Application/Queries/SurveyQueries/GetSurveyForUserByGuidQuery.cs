using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Queries.SurveyQueries
{
    public record GetSurveyForUserByGuidQuery(Guid UserGuid, Guid SurveyGuid) : IQuery<SurveyDTO>;
}
