using FluentValidation;
using PollPulse.Application.Commands.UserCommands;

namespace PollPulse.Validation.UserValidators;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(c => c.User.Username)
            .NotEmpty()
                .WithMessage("Username is required and can't be empty.");
        RuleFor(c => c.User.Password)
            .NotEmpty()
                .WithMessage("Password is required and can't be empty.");

    }
}
