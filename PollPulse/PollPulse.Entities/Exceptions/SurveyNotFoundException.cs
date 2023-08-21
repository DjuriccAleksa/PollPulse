using PollPulse.Entities.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Entities.Exceptions
{
    public class SurveyNotFoundException : NotFoundException
    {
        public SurveyNotFoundException(Guid guid) : base($"Survey with {guid} doesn't exist.")
        {
        }
    }
}
