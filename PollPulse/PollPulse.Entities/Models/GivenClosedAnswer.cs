using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class GivenClosedAnswer : IEntity
    {
        public int GivenAnswerId { get; set; }
        public int ClosedAnswerId { get; set; }
        public GivenAnswer GivenAnswer { get; set; }
        public ClosedAnswer ClosedAnswer { get; set; }
    }
}
