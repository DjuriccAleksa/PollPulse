using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class OpenedAnswer : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int GivenAnswerId { get; set; }

        public GivenAnswer GivenAnswer { get; set; }
    }
}
