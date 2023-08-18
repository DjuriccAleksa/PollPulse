using Microsoft.AspNetCore.Identity;
using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models
{
    public class User : IdentityUser<long>, IEntity
    {
        public Guid Guid { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Survey> Surveys { get; set; }
    }
}
