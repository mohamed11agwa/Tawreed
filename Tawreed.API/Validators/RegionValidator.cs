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
    public class PatchRegionValidator : AbstractValidator<PatchRegionDto>
    {
        public PatchRegionValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Region name must not exceed 100 characters.")
                .When(x => x.Name is not null);
        }
    }
}
