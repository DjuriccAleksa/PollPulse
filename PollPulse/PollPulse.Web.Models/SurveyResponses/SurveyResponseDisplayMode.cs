using PollPulse.Web.Models.QuestionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.SurveyResponses
{
    public class SurveyResponseDisplayModel : SurveyResponseCreateModel
    {
        public DateTime DateAnswered { get; set; }
        public string? Email { get; set; }
    }
}
