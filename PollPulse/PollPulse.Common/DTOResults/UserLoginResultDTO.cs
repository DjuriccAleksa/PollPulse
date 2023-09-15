using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTOResults
{
    public record UserLoginResultDTO : UserAuthBaseResultDTO
    {
        public string Token { get; init; } = "";
    }
}
