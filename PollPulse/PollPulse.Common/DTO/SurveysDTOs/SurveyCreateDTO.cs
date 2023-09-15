using PollPulse.Common.DTO.QuestionsDTOs;

namespace PollPulse.Common.DTO.SurveysDTOs;

public record SurveyCreateDTO(string Title, string? Description, List<QuestionCreateDTO> Questions);
