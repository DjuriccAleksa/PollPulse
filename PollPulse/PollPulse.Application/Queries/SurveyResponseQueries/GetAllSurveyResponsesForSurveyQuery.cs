using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using PollPulse.Common.RequestFeatrues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Queries.SurveyResponseQueries
{
    public record GetAllSurveyResponsesForSurveyQuery(Guid Guid, SurveyResponseSpecification SurveyResponseSpecification) : IQuery<(IEnumerable<SurveyResponseDTO> surveyResponses, PaginationData paginationData)>;
}
