using Blazorise;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using PollPulse.Common.DTOResults;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.HttpClientUtility;
using PollPulse.Web.Models.SurveyResponses;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;
using System.Text.Json;

namespace PollPulse.Web.Services.Implementations
{
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly HttpClient _httpClient;

        public SurveyResponseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagingResponse<SurveyResponseDisplayModel>> GetSurveyResponses(string guid, SurveyResponseSpecification surveyResponseSpecification)
        {
            var pageNumber = surveyResponseSpecification.PageNumber.ToString();
            var pageSize = surveyResponseSpecification.PageSize.ToString();

            var url = $"surveys/{guid}/responses?pageNumber={pageNumber}&pageSize={pageSize}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Greska ovde");

            var items = JsonSerializer.Deserialize<List<SurveyResponseDTO>>(
             content,
             new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var pagingResponse = new PagingResponse<SurveyResponseDisplayModel>()
            {
                Items = items.Select(i => new SurveyResponseDisplayModel
                {
                    DateAnswered = i.DateAnswered,
                    Email = i.Email,
                    QuestionResponses = i.QuestionResponses.Select(qr => new Models.QuestionResponses.QuestionGivenResponseModel
                    {
                        QuestionId = qr.QuestionId,
                        Text = qr.Text,
                        SelectedOptions = qr.SelectedOptions.Select(so => new Models.Options.QuestionOptionCreateModel
                        {
                            ClosedQuestionOptionId = so.ClosedQuestionOption.ClosedQuestionOptionId
                        }).ToList()
                    }).ToList()
                }).ToList(),
                PaginationData = JsonSerializer.Deserialize<PaginationData>(response.Headers.GetValues("X-Pagination").First())
            };

            return pagingResponse;
        }

        public async Task<object> SubmitResponse(string guid, SurveyResponseCreateModel surveyResponse)
        {
            var result = await HttpClientAPIHelper.PostAsync<SurveyResponseCreateModel, object>(_httpClient, $"surveys/{guid}/responses", surveyResponse);

            return result;
        }
    }
}
