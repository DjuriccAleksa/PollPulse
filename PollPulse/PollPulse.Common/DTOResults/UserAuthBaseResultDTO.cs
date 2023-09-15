using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTOResults
{
    public abstract record UserAuthBaseResultDTO
    {
        public bool IsSuccesfull { get; init; } = false;
        public IEnumerable<string>? Errors { get; init; }

    }

}
