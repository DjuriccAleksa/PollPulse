using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Components.QuestionResponses
{
    public partial class _OpenQuestionResponses
    {
        [Parameter] public QuestionsWithResponsesDisplayModel Question { get; set; }
         
    }
}
