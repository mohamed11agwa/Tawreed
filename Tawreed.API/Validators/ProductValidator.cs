using FluentValidation;
using Tawreed.BLL.Dtos.Product;
using Tawreed.DAL.Enums;

namespace Tawreed.API.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.Unit)
          .IsInEnum().WithMessage($"Invalid unit. Valid values: {string.Join(", ", Enum.GetNames<UnitOfMeasure>())}");
        }
    }

    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.Unit)
           .IsInEnum().WithMessage($"Invalid unit. Valid values: {string.Join(", ", Enum.GetNames<UnitOfMeasure>())}");
        }
    }
    public class PatchProductValidator : AbstractValidator<PatchProductDto>
    {
        public PatchProductValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.")
                .When(x => x.Name is not null);

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.")
                .When(x => x.Description is not null);

            RuleFor(x => x.Unit)
                .IsInEnum().WithMessage($"Invalid unit. Valid values: {string.Join(", ", Enum.GetNames<UnitOfMeasure>())}")
                .When(x => x.Unit is not null);

            RuleFor(x => x.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category id is not valid.")
                .When(x => x.CategoryId is not null);
        }
    }
}
