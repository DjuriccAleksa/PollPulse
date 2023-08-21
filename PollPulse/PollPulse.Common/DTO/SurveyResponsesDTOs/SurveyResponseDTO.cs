using PollPulse.Common.DTO.QuestionResponsesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.SurveyResponsesDTOs
{
    public record SurveyResponseDTO(DateTime DateAnswered, string? Email, List<QuestionResponseDTO> QuestionResponses);
}
