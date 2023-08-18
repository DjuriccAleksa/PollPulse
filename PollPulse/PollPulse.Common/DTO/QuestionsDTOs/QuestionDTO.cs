using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using PollPulse.Common.DTO.QuestionResponsesDTOs;

namespace PollPulse.Common.DTO.QuestionsDTOs;

public record QuestionDTO(string Text, string QuestionType, List<QuestionResponseDTO>? QuestionResponses, List<ClosedQuestionOptionDTO>? ClosedQuestionOptions);
