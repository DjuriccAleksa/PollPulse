using PollPulse.Web.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Surveys
{
    public class SurveyCreateModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public List<QuestionDisplayModel> Questions { get; set; }
    }
}
