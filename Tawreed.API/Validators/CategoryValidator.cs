using FluentValidation;
using Tawreed.BLL.Dtos.Category;
using Tawreed.DAL.Enums;

namespace Tawreed.API.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .IsInEnum().WithMessage($"Invalid category. Valid values: {string.Join(", ", Enum.GetNames<CategoryName>())}");
        }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .IsInEnum().WithMessage($"Invalid category. Valid values: {string.Join(", ", Enum.GetNames<CategoryName>())}");
        }
    }
}
