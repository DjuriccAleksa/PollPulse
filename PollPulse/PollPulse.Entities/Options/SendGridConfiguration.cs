using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Entities.Options
{
    public class SendGridConfiguration
    {
        public string Section { get; set; } = "SendGrid";

        public string? ApiKey { get; set; }

        public string? FromEmail { get; set; }
        public string? FromName { get; set; }
        public string? BaseUrl { get; set; }
    }
}
