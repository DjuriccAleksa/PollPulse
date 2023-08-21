using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class QuestionResponse : IEntity
    {
        public long SurveyId { get; set; }
        public long QuestionId { get; set; }
        public long SurveyResponseId { get; set; }

        public string Text { get; set; }

        public Question Question { get; set; }
        public SurveyResponse SurveyResponse { get; set; }
        public List<SelectedOption> SelectedOptions{ get; set; }
    }
}
