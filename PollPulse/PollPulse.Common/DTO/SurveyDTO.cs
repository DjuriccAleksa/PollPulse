using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO
{
    public record SurveyDTO(Guid Guid, string Title, string Description, DateTime DateCreated, DateTime DateFinished, List<QuestionDTO> Questions, int TotalResponses);
}
