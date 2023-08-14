using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PollPulse.Entities.Exceptions.ExceptionModel
{
    public class ExceptionDetails
    {
        public int StatusCode { get; set; }
        public string?  Message { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
