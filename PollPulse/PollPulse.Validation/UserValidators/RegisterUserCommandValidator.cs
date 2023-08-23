using FluentValidation;
using PollPulse.Application.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Validation.UserValidators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.User.FirstName)
            .NotEmpty()
                .WithMessage("First name is required and can't be empty.");
        RuleFor(c => c.User.LastName)
            .NotEmpty()
                .WithMessage("Last name is required and can't be empty.");
        RuleFor(c => c.User.Username)
            .NotEmpty()
                .WithMessage("Username is required and can't be empty.");
        RuleFor(c => c.User.FirstName)
            .NotEmpty()
                .WithMessage("First name is required and can't be empty.");
        RuleFor(c => c.User.Email)
            .NotEmpty()
                .WithMessage("Email is required and can't be empty.")
            .EmailAddress()
                .WithMessage("Email is not in valid format.");
        RuleFor(c => c.User.Password)
            .NotEmpty()
                .WithMessage("Password is required and can't be empty.");
    }
}
