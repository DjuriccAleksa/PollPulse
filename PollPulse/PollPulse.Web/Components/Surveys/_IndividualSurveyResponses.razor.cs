using Microsoft.AspNetCore.Components;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.Models.SurveyResponses;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Components.Surveys
{
    public partial class _IndividualSurveyResponses
    {
        [Inject] public ISurveyResponseService SurveyResponseService { get; set; }
        [Parameter] public SurveyDisplayModel Survey { get; set; }
        public SurveyResponseDisplayModel CurrentSurveyResponse { get; set; }
        public PaginationData PaginationData { get; set; }
        public SurveyResponseSpecification _surveyResponseSpecification = new();

        protected override async Task OnInitializedAsync()
        {
            _surveyResponseSpecification.PageSize = 1;

            await GetAllSurveyResponses();
        }

        private async Task GetAllSurveyResponses()
        {
            var result = await SurveyResponseService.GetSurveyResponses(Survey.Guid.ToString(), _surveyResponseSpecification);

            CurrentSurveyResponse = result.Items.FirstOrDefault();
            PaginationData = result.PaginationData;
        }

        private async Task SelectedPage(int page)
        {
            _surveyResponseSpecification.PageNumber = page;
            await GetAllSurveyResponses();
        }
    }
}
