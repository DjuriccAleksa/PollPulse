using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class OpenResponse : IEntity
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long QuestionResponseId { get; set; }

        public QuestionResponse QuestionResponse { get; set; }
    }
}
