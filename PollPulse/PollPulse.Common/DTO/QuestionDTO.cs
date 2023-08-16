using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO
{
    public record QuestionDTO(string Text, string QuestionType, List<GivenAnswerDTO>? GivenAnswers, List<ClosedAnswerDTO>? ClosedAnswers);
}
