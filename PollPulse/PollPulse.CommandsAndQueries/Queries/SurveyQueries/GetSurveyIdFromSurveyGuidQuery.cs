using PollPulse.CommandsAndQueries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Queries.SurveyQueries
{
    public record GetSurveyIdFromSurveyGuidQuery(Guid SurveyGuid) : IQuery<long>;
}
