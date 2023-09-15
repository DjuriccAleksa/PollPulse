using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Surveys
{
    [Authorize]
    public partial class MySurveysPage
    {
        [Inject]
        public ISurveysService SurveysService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public List<SurveyDisplayModel> Surveys { get; set; }
        public PaginationData PaginationData { get; set; } = new();
        public SurveySpecification _surveySpecification = new();

        protected override async Task OnInitializedAsync()
        {
            await GetAllSurveys();
        }

        private async Task SelectedPage(int page)
        {
            _surveySpecification.PageNumber = page;
            await GetAllSurveys();
        }

        private async Task GetAllSurveys()
        {
            var pagingResult = await SurveysService.GetAllSurveys(_surveySpecification);
            Surveys = pagingResult.Items;
            PaginationData = pagingResult.PaginationData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            _surveySpecification.PageNumber = 1;
            _surveySpecification.SearchTerm = searchTerm;
            await GetAllSurveys();
        }

        private async Task SortChanged(string orderBy)
        {
            _surveySpecification.OrderBy = orderBy;
            await GetAllSurveys();
        }

        private async Task FilterChanged(DateTime? filterDate)
        {
            _surveySpecification.DateCreatedAfter = filterDate ?? default(DateTime);
            await GetAllSurveys();
        }

        private async Task HandleSurveyDelete(string surveyGuid)
        {
            await SurveysService.DeleteSurvey(surveyGuid);
            await GetAllSurveys();
        }

        private async Task HandleSurveyFinish(string surveyGuid)
        {
            await SurveysService.FinishSurvey(surveyGuid);
            await GetAllSurveys();
        }

        private void CreateNewSurvey() => NavigationManager.NavigateTo("surveys/create");
            }
}
