using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO
{
    public record SurveyCreateDTO(string Title, string? Description, List<QuestionDTO> Questions);
}
