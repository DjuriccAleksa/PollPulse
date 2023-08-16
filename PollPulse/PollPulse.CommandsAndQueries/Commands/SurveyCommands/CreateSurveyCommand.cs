using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO;

namespace PollPulse.CommandsAndQueries.Commands.SurveyCommands
{
    public record CreateSurveyCommand(Guid UserGuid, SurveyCreateDTO Survey) : ICommand<SurveyDTO>;
}
