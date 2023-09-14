using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Questions;
using PollPulse.Web.Models.SurveyResponses;

namespace PollPulse.Web.Components.Questions
{
    public partial class _BaseQuestionList
    {
        [Parameter]
        public List<QuestionDisplayModel> Questions { get; set; }
        [Parameter]
        public SurveyResponseCreateModel SurveyResponse { get; set; }

        protected virtual RenderFragment RenderQuestion(QuestionDisplayModel question)
        {
            var questionResponse = SurveyResponse.QuestionResponses.FirstOrDefault(q => q.QuestionId == question.Id);

            return builder =>
            {
                builder.OpenComponent<_Question>(0);
                builder.AddAttribute(1, "Question", question);
                builder.AddAttribute(2, "QuestionNumber", Questions.IndexOf(question) + 1);
                builder.AddAttribute(3, "Response", questionResponse);
                builder.CloseComponent();
            };
        }
    }
}
