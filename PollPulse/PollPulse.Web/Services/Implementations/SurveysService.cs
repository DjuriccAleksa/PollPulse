using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Common.DTOResults;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.HttpClientUtility;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace PollPulse.Web.Services.Implementations;

public class SurveysService : ISurveysService
{
    private readonly HttpClient _httpClient;

    public SurveysService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SurveyDisplayModel> CreateSurvey(SurveyCreateModel survey)
    {
        var result = await HttpClientAPIHelper.PostAsync<SurveyCreateModel, SurveyDisplayModel>(_httpClient, APIRoutes.SURVEY_BASE, survey);

        return result;
    }

    public async Task DeleteSurvey(string surveyGuid)
    {
        var result = await _httpClient.DeleteAsync($"{APIRoutes.SURVEY_BASE}/{surveyGuid}");
        var content = await result.Content.ReadAsStringAsync();

        await Task.CompletedTask;
    }

    public async Task FinishSurvey(string surveyGuid)
    {
        var patchDoc = new JsonPatchDocument<SurveyUpdateDTO>();
        patchDoc.Add(s => s.DateFinished, DateTime.Now);

        var content = JsonConvert.SerializeObject(patchDoc);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json-patch+json");

        var response = await _httpClient.PatchAsync($"{APIRoutes.SURVEY_BASE}/{surveyGuid}", bodyContent);
        var responseContent = await response.Content.ReadAsStringAsync();

        await Task.CompletedTask;

    }

    public async Task<PagingResponse<SurveyDisplayModel>> GetAllSurveys(SurveySpecification surveySpecification)
    {
        var pageNumber = surveySpecification.PageNumber.ToString();
        var pageSize = surveySpecification.PageSize.ToString();
        var serachTerm = surveySpecification.SearchTerm == null ? "" : surveySpecification.SearchTerm;
        var orderBy = surveySpecification.OrderBy;
        var dateCreatedAfter = surveySpecification.DateCreatedAfter.ToString("yyyy-MM-dd");

        var url = $"{APIRoutes.SURVEY_BASE}?pageNumber={pageNumber}&pageSize={pageSize}&searchTerm={serachTerm}&orderBy={orderBy}&dateCreatedAfter={dateCreatedAfter}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode == false)
            throw new Exception("Greska ovde");

        var pagingResponse = new PagingResponse<SurveyDisplayModel>()
        {
            Items = System.Text.Json.JsonSerializer.Deserialize<List<SurveyDisplayModel>>(
             content,
             new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
            PaginationData = System.Text.Json.JsonSerializer.Deserialize<PaginationData>(response.Headers.GetValues("X-Pagination").First())
        };

        return pagingResponse;
    }

    public async Task<SurveyDisplayModel> GetSurvey(string surveyGuid)
    {
        var response = await _httpClient.GetAsync($"{APIRoutes.SURVEY_BASE}/{surveyGuid}");
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode == false)
            throw new Exception("Greska u dobijanju surveya");

        var survey = System.Text.Json.JsonSerializer.Deserialize<SurveyDisplayModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return survey;
    }
}
