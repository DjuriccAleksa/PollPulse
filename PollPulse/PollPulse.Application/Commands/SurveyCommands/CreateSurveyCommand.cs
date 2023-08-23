using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;

namespace PollPulse.Application.Commands.SurveyCommands
{
    public record CreateSurveyCommand(Guid UserGuid, SurveyCreateDTO Survey) : ICommand<SurveyDTO>;
}
