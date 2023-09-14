using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models;
using PollPulse.Web.Models.Options;
using PollPulse.Web.Models.QuestionResponses;
using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Components.Questions
{
    public partial class _Question
    {
        [Parameter]
        public QuestionDisplayModel Question { get; set; }
        [Parameter]
        public int QuestionNumber { get; set; }
        [Parameter]
        public bool IsReadOnly { get; set; } = false;
        [Parameter]
        public bool IsEditable { get; set; } = false;

        [CascadingParameter(Name = "DeleteQuestionAction")]
        public EventCallback<QuestionDisplayModel> DeleteQuestion { get; set; }
        [CascadingParameter(Name = "EditQuestionAction")]
        public EventCallback<QuestionDisplayModel> EditQuestion { get; set; }

        [Parameter]
        public QuestionGivenResponseModel Response { get; set; }

        private async Task OnDelete()
        {
            await DeleteQuestion.InvokeAsync(Question);
        }
        private async Task OnEdit()
        {
            await EditQuestion.InvokeAsync(Question);
        }

        protected override void OnParametersSet()
        {
           if(Response is not null)
            {
                if (Question.QuestionType != QuestionType.OPEN)
                    Response.SelectedOptions = new();
            }

        }

        private void HandleRadioButtonChange(QuestionOptionDisplayModel option)
        {
            Response.SelectedOptions.Clear();
            Response.SelectedOptions.Add(new QuestionOptionCreateModel { ClosedQuestionOptionId = option.Id});
        }

        private void HandleCheckboxChange(QuestionOptionDisplayModel option)
        {
            var selectedOption = Response.SelectedOptions.FirstOrDefault(o => o.ClosedQuestionOptionId == option.Id);
            if(selectedOption is not null)
                Response.SelectedOptions.Remove(selectedOption);
            else
                Response.SelectedOptions?.Add(new QuestionOptionCreateModel { ClosedQuestionOptionId = option.Id});
        }

       
    }
}
