using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PollPulse.Web.Models.Surveys;

namespace PollPulse.Web.Components.Surveys
{
    public partial class _SurveyCard
    {
        [Parameter, EditorRequiredAttribute]
        public SurveyDisplayModel? Survey { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public EventCallback<string> OnSurveyDelete { get; set; }

        [Parameter]
        public EventCallback<string> OnSurveyFinish { get; set; }
        private async void CopyLinkToClipboard()
        {
            var surveyLink = $"{NavigationManager.BaseUri}survey/{Survey.Guid}";

            await JSRuntime.InvokeVoidAsync("navigator.clipboard.writeText", surveyLink);
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", "Copied to clipboard!");
        }

        private async void FinishSurvey(string guid)
        {
            await OnSurveyFinish.InvokeAsync(guid);
        }

        private async void DeleteSurvey(string guid)
        {
            await OnSurveyDelete.InvokeAsync(guid);
        }

        void NavigateToSurveyDetails()
        {
            NavigationManager.NavigateTo($"surveys/survey-details/{Survey.Guid}");
        }

    }
}
