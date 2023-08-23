using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.SurveysDTOs;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Commands.SurveyCommands
{
    public record UpdateSurveyPatchCommand(SurveyUpdateDTO SurveyUpdateDTO, Survey Survey) : ICommand;
}
