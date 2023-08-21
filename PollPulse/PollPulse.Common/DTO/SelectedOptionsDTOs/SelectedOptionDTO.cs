using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Common.DTO.SelectedOptionsDTOs
{
    public record SelectedOptionDTO(ClosedQuestionOptionDTO ClosedQuestionOption);
}
