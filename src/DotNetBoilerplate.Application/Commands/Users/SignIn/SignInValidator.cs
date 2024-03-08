using FluentValidation;

namespace DotNetBoilerplate.Application.Commands.Users.SignIn;

internal sealed class SignInValidator : AbstractValidator<SignIn>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();

        RuleFor(x => x.Password)
            .MinimumLength(2)
            .MaximumLength(50)
            .NotNull();
    }
}