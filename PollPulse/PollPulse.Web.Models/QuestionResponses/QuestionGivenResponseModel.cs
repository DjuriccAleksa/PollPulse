using PollPulse.Web.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Web.Models.QuestionResponses
{
    public class QuestionGivenResponseModel
    {
        public long QuestionId { get; set; }
        public string? Text { get; set; }
        public List<QuestionOptionCreateModel>? SelectedOptions { get; set; } 
    }
}
