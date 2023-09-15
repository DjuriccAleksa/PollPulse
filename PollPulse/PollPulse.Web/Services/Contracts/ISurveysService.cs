using PollPulse.Common.DTOResults;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.Models.Surveys;

namespace PollPulse.Web.Services.Contracts
{
    public interface ISurveysService
    {
        Task<PagingResponse<SurveyDisplayModel>> GetAllSurveys(SurveySpecification surveySpecification);
        Task<SurveyDisplayModel> CreateSurvey(SurveyCreateModel survey);
        Task<SurveyDisplayModel> GetSurvey(string surveyGuid);
        Task DeleteSurvey(string surveyGuid);
        Task FinishSurvey(string surveyGuid);   
    }
}
