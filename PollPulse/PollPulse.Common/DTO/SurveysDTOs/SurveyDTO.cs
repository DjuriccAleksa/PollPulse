using PollPulse.Common.DTO.QuestionsDTOs;

namespace PollPulse.Common.DTO.SurveysDTOs;

public record SurveyDTO(Guid Guid, string Title, string Description, DateTime DateCreated, DateTime DateFinished, List<QuestionDTO> Questions, int TotalResponses);
