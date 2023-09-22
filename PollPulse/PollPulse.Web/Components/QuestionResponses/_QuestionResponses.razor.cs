using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Questions;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Components.QuestionResponses
{
    public partial class _QuestionResponses
    {
        [Inject] public IQuestionsService QuestionsService { get; set; }
        [Parameter] public string SurveyGuid { get; set; }
        [Parameter] public List<QuestionDisplayModel> QuestionsList { get; set; }

        private QuestionDisplayModel selectedQuestion;

        public QuestionsWithResponsesDisplayModel Question { get; set; }

        protected override void OnInitialized()
        {
            QuestionsList.Insert(0, new QuestionDisplayModel { Text = "Choose question...", Id = -1 });
            selectedQuestion = QuestionsList[0];
        }

        private async void LoadQuestionResponses(QuestionDisplayModel selectedQuestionModel)
        {
            if (selectedQuestionModel is not null && selectedQuestionModel.Id != -1)
            {
                selectedQuestion = selectedQuestionModel;
                Question = await QuestionsService.GetQuestion(SurveyGuid, selectedQuestionModel.Id);

                StateHasChanged();
            }
        }
    }
}
