using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Surveys
{
    public partial class SurveyDetailsPage
    {
        [Inject]
        public ISurveysService SurveysService{ get; set; }

        [Parameter]
        public string SurveyGuid { get; set; }

        public SurveyDisplayModel Survey { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Survey = await SurveysService.GetSurvey(SurveyGuid);

            if(Survey is null)
            {
                Survey = new SurveyDisplayModel
                {
                    Title = "GRESKAAA"
                };
                return;
            }


        }
    }
}
