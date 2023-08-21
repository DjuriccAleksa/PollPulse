using PollPulse.CommandsAndQueries.Interfaces;
using PollPulse.Common.DTO.SurveyResponsesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.CommandsAndQueries.Commands.SurveyResponseCommands
{
    public record SubmitNewSurveyResponseCommand(long SurveyId, SurveyResponseCreateDTO SurveyResponseCreate) : ICommand;
}
