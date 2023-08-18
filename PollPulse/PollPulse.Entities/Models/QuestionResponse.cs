using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class QuestionResponse : IEntity
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public Question Question { get; set; }

        public long SurveyResponseId{ get; set; }
        public SurveyResponse SurveyResponse { get; set; }

        public OpenResponse OpenResponse { get; set; }

        public List<SelectedOption> SelectedOptions{ get; set; }
    }
}
