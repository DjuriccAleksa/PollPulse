using Microsoft.AspNetCore.Components;
using PollPulse.Web.Components.QuestionOptions;
using PollPulse.Web.Models;
using PollPulse.Web.Models.Options;
using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Components.Questions
{
    public partial class _QuestionEditor
    {
        [Parameter]
        public QuestionDisplayModel Question { get; set; } = new();
        [Parameter]
        public EventCallback<QuestionDisplayModel> OnQuestionCreated { get; set; }
        private _QuestionOptionsEditor _optionsEditor;
        private bool showQuestionOptions = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            showQuestionOptions = Question.QuestionType != QuestionType.OPEN;
        }

        private async Task CreateQuestion()
        {
            Question.ClosedQuestionOptions = _optionsEditor?.Options;
            await OnQuestionCreated.InvokeAsync(Question);
        }

        public void AddOptionToQuestion(QuestionOptionDisplayModel option)
        {
            Question.ClosedQuestionOptions = _optionsEditor.Options;
            Question.ClosedQuestionOptions.Add(option);
        }

        private void OnQuestionTypeChanged(string value)
        {
            Question.QuestionType = value;
            showQuestionOptions = value != QuestionType.OPEN;
            StateHasChanged();
        }

    }


}
