using PollPulse.Common.DTOResults;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.Models.SurveyResponses;

namespace PollPulse.Web.Services.Contracts
{
    public interface ISurveyResponseService
    {
        Task<object> SubmitResponse(string guid, SurveyResponseCreateModel surveyResponse);
        Task<PagingResponse<SurveyResponseDisplayModel>> GetSurveyResponses(string guid, SurveyResponseSpecification surveyResponseSpecification);
    }
}
