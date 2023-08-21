using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class SelectedOption : IEntity
    {
        public long SurveyId { get; set; }
        public long QuestionId { get; set; }
        public long ClosedQuestionOptionId { get; set; }
        public long SurveyResponseId { get; set; }
        public QuestionResponse QuestionResponse { get; set; }
        public ClosedQuestionOption ClosedQuestionOption { get; set; }
    }
}
