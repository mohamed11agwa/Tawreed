using FluentValidation;
using Tawreed.BLL.Constants;

namespace Tawreed.BLL.Contracts.Authentication;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(X => X.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(X => X.Password)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should at least 8 digits and should contain Lowercase, NonAlphanumeric & Uppercase");

        RuleFor(X => X.FullName)
            .NotEmpty()
            .Length(3, 100);

    }
}