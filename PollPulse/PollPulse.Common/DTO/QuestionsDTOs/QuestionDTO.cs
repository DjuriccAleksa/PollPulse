using PollPulse.Common.DTO.ClosedQuestionOptionsDTOs;
using PollPulse.Common.DTO.QuestionResponsesDTOs;

namespace PollPulse.Common.DTO.QuestionsDTOs;

public record QuestionDTO(long Id, string Text, string QuestionType, List<QuestionResponseDTO>? QuestionResponses, List<ClosedQuestionOptionDTO>? ClosedQuestionOptions);
