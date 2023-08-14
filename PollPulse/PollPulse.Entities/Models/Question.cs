using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType{ get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public List<GivenAnswer> GivenAnswers { get; set; }
        public List<ClosedAnswer> ClosedAnswers { get; set; }
    }
}
