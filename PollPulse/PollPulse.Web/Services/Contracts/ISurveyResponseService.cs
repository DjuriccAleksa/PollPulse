using PollPulse.Web.Models.SurveyResponses;

namespace PollPulse.Web.Services.Contracts
{
    public interface ISurveyResponseService
    {
        Task<object> SubmitResponse(string guid, SurveyResponseCreateModel surveyResponse);
    }
}
