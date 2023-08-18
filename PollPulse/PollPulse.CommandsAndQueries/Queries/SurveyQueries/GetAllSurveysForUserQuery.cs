using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.RequestFeatrues;

namespace PollPulse.CommandsAndQueries.Queries.SurveyQueries
{
    public record GetAllSurveysForUserQuery(Guid Guid, SurveySpecification SurveySpecification) : IQuery<(IEnumerable<SurveyDTO> Surveys, PaginationData PaginationData)>;
}
