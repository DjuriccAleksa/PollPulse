using FluentValidation;
using PollPulse.Application.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.UserValidators
{
    public class ResetUserPasswordCommandValidator : AbstractValidator<ResetUserPasswordCommand>
    {
        public ResetUserPasswordCommandValidator()
        {
            RuleFor(c => c.User.Password)
                .NotEmpty()
                    .WithMessage("Password can't be empty");
            RuleFor(c => c.User.ConfirmPassword)
                .Equal(cmd => cmd.User.Password)
                    .WithMessage("Password doesn't match");


        }
    }
}
