using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Components.QuestionResponses
{
    public partial class _ClosedQuestionResponses
    {
        [Parameter] public QuestionsWithResponsesDisplayModel Question { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}
