using PollPulse.CommandsAndQueries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.SurveyCommands
{
    public record DeleteSurveyCommand(Guid UserGuid, Guid SurveyGuid) : ICommand;
}
