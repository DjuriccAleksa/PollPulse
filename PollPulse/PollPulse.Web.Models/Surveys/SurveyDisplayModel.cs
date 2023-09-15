using PollPulse.Web.Models.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.Surveys
{
    public class SurveyDisplayModel
    {
        public string Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateFinished { get; set; }
        public int TotalResponses { get; set; }
        public List<QuestionDisplayModel> Questions{ get; set; }
    }
}
