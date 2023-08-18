using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class SurveyResponse : IEntity
    {
        public long Id { get; set; }
        public DateTime DateAnswered { get; set; }

        public long SurveyId { get; set; }
        public Survey Survey { get; set; }

        public List<QuestionResponse> QuestionResponses { get; set; }
    }
}
