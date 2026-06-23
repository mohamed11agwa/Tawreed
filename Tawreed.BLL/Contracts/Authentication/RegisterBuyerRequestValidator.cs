using FluentValidation;
using Tawreed.DAL.Consts;

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

        RuleFor(x => x.PreferredLang)
            .NotEmpty()
            .Must(lang => lang == "ar" || lang == "en")
            .WithMessage("PreferredLang must be either 'ar' or 'en'");

        RuleFor(x => x.BusinessName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.BusinessType)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.TaxNumber)
        .MaximumLength(50);

        RuleFor(x => x.RatingAvg)
           .Must(BeValidRating)
           .WithMessage("Rating must be between 0.00 and 5.00");

        RuleFor(x => x.Address)
            .MaximumLength(500);

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90);

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180);

        RuleFor(x => x.RegionId)
            .NotEmpty()
            .WithMessage("Region is required.");
    }


    private bool BeValidRating(decimal rating)
    {
        return rating >= 0 && rating <= 5;
    }
}
