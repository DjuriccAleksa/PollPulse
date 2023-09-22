using PollPulse.Web.Models.Options;
using PollPulse.Web.Models.QuestionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Questions
{
    public class QuestionsWithResponsesDisplayModel
    {
        public long Id { get; set; }
        public string Text { get; set; } = "";
        public string QuestionType { get; set; } = Models.QuestionType.OPEN;
        public List<QuestionOptionDisplayModel> ClosedQuestionOptions { get; set; }
        public List<QuestionGivenResponseWithSelectedOptionObjectDisplayModel> QuestionResponses { get; set; }

    }
}
