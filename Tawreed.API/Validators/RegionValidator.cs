using FluentValidation;
using Tawreed.BLL.Dtos.Reigon;

namespace Tawreed.API.Validators
{
    public class CreateRegionValidator : AbstractValidator<CreateRegionDto>
    {
        public CreateRegionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Region name is required.")
                .MaximumLength(100).WithMessage("Region name must not exceed 100 characters.");
        }
    }

    public class UpdateRegionValidator : AbstractValidator<UpdateRegionDto>
    {
        public UpdateRegionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Region name is required.")
                .MaximumLength(100).WithMessage("Region name must not exceed 100 characters.");
        }
    }

}
