using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class ClosedAnswer : IEntity
    {
        public int Id { get; set; }
        public string TextOption { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public List<GivenClosedAnswer> GivenClosedAnswers { get; set; }
    }
}
