using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class ClosedQuestionOption : IEntity
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public long SurveyId { get; set; }
        public string TextOption { get; set; }

        public Question Question { get; set; }

        public List<SelectedOption> SelectedOptions { get; set; }
    }
}
