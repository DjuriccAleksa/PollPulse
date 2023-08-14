using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class GivenAnswer : IEntity
    {
        public int Id { get; set; }
        public DateTime DateAnswered { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public OpenedAnswer OpenedAnswer { get; set; }

        public List<GivenClosedAnswer> GivenClosedAnswers{ get; set; }
    }
}
