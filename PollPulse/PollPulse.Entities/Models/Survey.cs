using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class Survey : IEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateFinished { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public List<Question> Questions { get; set; }
        public List<SurveyResponse> SurveyResponses { get; set; }
    }
}
