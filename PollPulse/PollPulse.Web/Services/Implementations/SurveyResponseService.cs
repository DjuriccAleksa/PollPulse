using PollPulse.Web.HttpClientUtility;
using PollPulse.Web.Models.SurveyResponses;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Services.Implementations
{
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly HttpClient _httpClient;

        public SurveyResponseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> SubmitResponse(string guid, SurveyResponseCreateModel surveyResponse)
        {
            var result = await HttpClientAPIHelper.PostAsync<SurveyResponseCreateModel, object>(_httpClient, $"surveys/{guid}/responses", surveyResponse);

            return result;
        }
    }
}
