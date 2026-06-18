using FluentValidation;
using Tawreed.BLL.Constants;

namespace Tawreed.BLL.Contracts.Authentication;

public class RegisterBuyerRequestValidator : AbstractValidator<RegisterBuyerRequest>
{
    public RegisterBuyerRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 characters and contain Uppercase, Lowercase, Number & Special character.");

        RuleFor(x => x.BusinessName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.BusinessType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.RegionId)
            .NotEqual(Guid.Empty).WithMessage("Region is required.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(500);
    }
}
