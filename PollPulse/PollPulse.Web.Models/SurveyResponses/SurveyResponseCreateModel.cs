using PollPulse.Web.Models.QuestionResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.SurveyResponses
{
    public class SurveyResponseCreateModel
    {
        public List<QuestionGivenResponseModel> QuestionResponses { get; set; } = new();
    }
}
