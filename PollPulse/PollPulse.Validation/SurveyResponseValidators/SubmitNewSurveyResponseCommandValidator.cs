using FluentValidation;
using PollPulse.Application.Commands.SurveyResponseCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.SurveyResponseValidators
{
    public class SubmitNewSurveyResponseCommandValidator : AbstractValidator<SubmitNewSurveyResponseCommand>
    {
        public SubmitNewSurveyResponseCommandValidator()
        {
            RuleFor(c => c.SurveyResponseCreate.QuestionResponses)
                .Must(qr => qr.Count > 0)
                    .WithMessage("Survey response must containt answers.");

        }
    }
}
