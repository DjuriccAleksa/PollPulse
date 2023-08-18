using PollPulse.Common.DTO.OpenResponsesDTOs;

namespace PollPulse.Common.DTO.QuestionResponsesDTOs;

public record QuestionResponseDTO(DateTime DateAnswered, OpenResponseDTO? OpenResponse);
