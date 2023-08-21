using PollPulse.Common.DTO.QuestionResponsesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.SurveyResponsesDTOs
{
    public record SurveyResponseCreateDTO(string? Email, List<QuestionResponseCreateDTO> QuestionResponses);
}
