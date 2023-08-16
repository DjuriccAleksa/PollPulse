using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;

namespace PollPulse.CommandsAndQueries.Queries.SurveyQueries
{
    public record GetAllSurveysForUserQuery(Guid Guid) : IQuery<IEnumerable<SurveyDTO>>;
}
