using PollPulse.Common.DTO.OpenResponsesDTOs;
using PollPulse.Common.DTO.SelectedOptionsDTOs;

namespace PollPulse.Common.DTO.QuestionResponsesDTOs;

public record QuestionResponseCreateDTO(long QuestionId, string? Text, List<SelectedOptionCreateDTO>? SelectedOptions);
