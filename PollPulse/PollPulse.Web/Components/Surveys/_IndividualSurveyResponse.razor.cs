using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.SurveyResponses;
using PollPulse.Web.Models.Surveys;

namespace PollPulse.Web.Components.Surveys
{
    public partial class _IndividualSurveyResponse
    {
        [Parameter] public SurveyDisplayModel Survey { get; set; }
        [Parameter] public SurveyResponseDisplayModel Response { get; set; }
    }
}
