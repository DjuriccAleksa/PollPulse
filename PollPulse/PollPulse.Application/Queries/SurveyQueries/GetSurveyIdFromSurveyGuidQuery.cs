using PollPulse.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Queries.SurveyQueries
{
    public record GetSurveyIdFromSurveyGuidQuery(Guid SurveyGuid) : IQuery<long>;
}
