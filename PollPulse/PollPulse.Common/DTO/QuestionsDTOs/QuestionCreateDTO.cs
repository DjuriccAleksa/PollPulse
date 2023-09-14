using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.QuestionsDTOs
{
    public record QuestionCreateDTO(string Text,string QuestionType, List<ClosedQuestionOptionDTO>? ClosedQuestionOptions);
}
