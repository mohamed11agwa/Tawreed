using FluentValidation;
using Tawreed.API.Validators;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Dtos.Category;
using Tawreed.BLL.Dtos.Product;
using Tawreed.BLL.Dtos.Reigon;

namespace Tawreed.API.Registration.Sub
{
    public  static class ValidatorsRegistrations
    {
        public static IServiceCollection AddValidatorsRegistration(
      this IServiceCollection services)
        {
            //Auth 
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<RegisterBuyerRequest>, RegisterBuyerRequestValidator>();
            services.AddScoped<IValidator<RegisterSupplierRequest>, RegisterSupplierRequestValidator>();

            // Category
            services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryValidator>();
            services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();

            // Region
            services.AddScoped<IValidator<CreateRegionDto>, CreateRegionValidator>();
            services.AddScoped<IValidator<UpdateRegionDto>, UpdateRegionValidator>();
            services.AddScoped<IValidator<PatchRegionDto>, PatchRegionValidator>();

            // Product
            services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();
            services.AddScoped<IValidator<PatchProductDto>, PatchProductValidator>();

            return services;
        }
    }
}
