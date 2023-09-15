using PollPulse.Common.DTO.SelectedOptionsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.QuestionResponsesDTOs
{
    public record QuestionResponseDTO(long QuestionId, string? Text, List<SelectedOptionDTO> SelectedOptions);
}
