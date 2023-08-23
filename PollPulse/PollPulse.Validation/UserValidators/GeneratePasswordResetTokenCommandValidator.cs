using FluentValidation;
using PollPulse.Application.Commands.UserCommands;

namespace PollPulse.Validation.UserValidators;

public class GeneratePasswordResetTokenCommandValidator : AbstractValidator<GeneratePasswordResetTokenCommand>
{
	public GeneratePasswordResetTokenCommandValidator()
	{
		RuleFor(c => c.Email)
			.NotEmpty()
				.WithMessage("Email address can't be empty.")
			.EmailAddress()
				.WithMessage("Email address is not in good format.");
	}
}
