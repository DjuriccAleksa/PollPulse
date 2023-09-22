using PollPulse.Web.HttpClientUtility;
using PollPulse.Web.Models.Questions;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;
using System.Text.Json;

namespace PollPulse.Web.Services.Implementations
{
    public class QuestionsService : IQuestionsService
    {
        private readonly HttpClient _httpClient;

        public QuestionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<QuestionsWithResponsesDisplayModel> GetQuestion(string surveyGuid, long questionId)
        {
            var response = await _httpClient.GetAsync($"{APIRoutes.SURVEY_BASE}/{surveyGuid}/questions/{questionId}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Greska u dobijanju questiona");

            var question = JsonSerializer.Deserialize<QuestionsWithResponsesDisplayModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return question;
        }
    }
}
