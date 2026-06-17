using FluentValidation;
using Tawreed.API.Validators;
using Tawreed.BLL.Services.BuyerService;
using Tawreed.BLL.Services.CategoryService;
using Tawreed.BLL.Services.ProductService;
using Tawreed.BLL.Services.RegionService;
using Tawreed.DAL.Repository.CategoryRepo;
using Tawreed.DAL.Repository.ProductRepo;
using Tawreed.DAL.Repository.RegionRepo;
using Tawreed.DAL.Repository.Supplier_Repo;

namespace Tawreed.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddDependencies(builder.Configuration);


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add FluentValidation validators for region DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateRegionValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateRegionValidator>();
            //Add FluentValidation validators for category DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
            //Add FluentValidation validators for product DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductValidator>();
            /*------------------------------------------------*/
            // Add other services, repositories, and configurations as needed

            
            var app = builder.Build();
   


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
