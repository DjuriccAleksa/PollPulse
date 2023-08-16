using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Queries.SurveyQueries
{
    public record GetSurveyByGuidQuery(Guid UserGuid, Guid SurveyGuid) : IQuery<SurveyDTO>;
}
