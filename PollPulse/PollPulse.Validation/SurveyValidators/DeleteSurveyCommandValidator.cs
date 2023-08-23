using FluentValidation;
using PollPulse.Application.Commands.SurveyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.SurveyValidators
{
    public class DeleteSurveyCommandValidator : AbstractValidator<DeleteSurveyCommand>
    {
        public DeleteSurveyCommandValidator()
        {
            RuleFor(c => c.UserGuid)
                .NotEmpty()
                    .WithMessage("User guid is not in valid format.");

            RuleFor(c => c.SurveyGuid)
                .NotEmpty()
                    .WithMessage("Survey guid is not in valid format.");
        }
    }
}
