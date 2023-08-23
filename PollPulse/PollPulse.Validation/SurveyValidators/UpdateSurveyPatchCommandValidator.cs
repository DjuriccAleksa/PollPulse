using FluentValidation;
using PollPulse.Application.Commands.SurveyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.SurveyValidators
{
    public class UpdateSurveyPatchCommandValidator : AbstractValidator<UpdateSurveyPatchCommand>
    {
        public UpdateSurveyPatchCommandValidator()
        {
            RuleFor(c => c.SurveyUpdateDTO)
                .NotEmpty()
                    .WithMessage("Surve for update can't be empty.");

            RuleFor(c => c.SurveyUpdateDTO.DateFinished)
                .NotEmpty()
                    .WithMessage("Date finished for survey can't be empty.")
                .Must((cmd, dateFinished) => dateFinished > cmd.Survey.DateCreated)
                    .WithMessage("Date finished must be after survey's date creation.")
                .Must(dateFinished => dateFinished < DateTime.Now)
                    .WithMessage("Date finished can't be set in future");
        }
    }
}
