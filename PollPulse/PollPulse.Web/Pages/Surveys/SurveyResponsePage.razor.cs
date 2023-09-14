using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.QuestionResponses;
using PollPulse.Web.Models.SurveyResponses;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Surveys
{
    public partial class SurveyResponsePage
    {
        [Inject]
        public ISurveysService SurveysService{ get; set; }
        [Inject]
        public ISurveyResponseService SurveyResponseService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public int MyProperty { get; set; }
        [Parameter]
        public string Guid { get; set; }
        public SurveyDisplayModel Survey{ get; set; }
        public SurveyResponseCreateModel SurveyResponse { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            Survey = await SurveysService.GetSurvey(Guid);

            if(Survey is null)
            {
                Survey = new SurveyDisplayModel
                {
                    Title = "GRESKAAA"
                };
                return;
            }

            foreach(var question in Survey.Questions)
            {
                SurveyResponse.QuestionResponses.Add(new QuestionGivenResponseModel
                {
                    QuestionId = question.Id
                });
            }

            StateHasChanged();
        }

        private async void SubmitResponse()
        {
            var res = await SurveyResponseService.SubmitResponse(Guid, SurveyResponse);

            NavigationManager.NavigateTo("/survey-submit");
        }
    }
}
