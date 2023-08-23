using FluentValidation;
using PollPulse.Application.Commands.SurveyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.SurveyValidators
{
    public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
    {
        public CreateSurveyCommandValidator()
        {
            RuleFor(c => c.UserGuid)
                .NotEmpty()
                    .WithMessage("User guid is not in valid format.");

            RuleFor(c => c.Survey)
                .NotEmpty()
                    .WithMessage("Survey object for creation can't be empty.");

            RuleFor(c => c.Survey.Title)
                .NotEmpty()
                    .WithMessage("Survey title can't be empty.")
                .MinimumLength(5)
                    .WithMessage("Survey title must be at least 5 characters long.")
                .MaximumLength(50)
                    .WithMessage("Survey title can't be longer then 50 characters.");

            RuleFor(c => c.Survey.Questions)
                .NotEmpty()
                    .WithMessage("Survey must have atleast one question.")
                .Must(q => q.Count <= 35)
                    .WithMessage("Maximum number of questions is 35");
        }
    }
}
