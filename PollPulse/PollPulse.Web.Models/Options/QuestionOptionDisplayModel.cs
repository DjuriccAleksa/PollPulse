using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Options
{
    public class QuestionOptionDisplayModel
    {
        public long ClosedQuestionOptionId { get; set; }
        public string TextOption { get; set; } = "";
    }
}
