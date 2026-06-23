using FluentValidation;
using Tawreed.DAL.Consts;

namespace Tawreed.BLL.Contracts.Authentication;

public class RegisterSupplierRequestValidator : AbstractValidator<RegisterSupplierRequest>
{
    public RegisterSupplierRequestValidator()
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

        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.TaxId)
            .MaximumLength(50)
            .When(x => x.TaxId is not null);

        RuleFor(x => x.CommercialRegister)
            .MaximumLength(100)
            .When(x => x.CommercialRegister is not null);

        RuleFor(x => x.RegionIds)
            .NotEmpty().WithMessage("At least one region is required.")
            .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid region id in list.");

        RuleFor(x => x.CategoryIds)
            .NotEmpty().WithMessage("At least one category is required.")
            .Must(ids => ids.All(id => id != Guid.Empty)).WithMessage("Invalid category id in list.");
    }
}