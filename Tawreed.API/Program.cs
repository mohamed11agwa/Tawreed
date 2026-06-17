
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Tawreed.API.Validators;
using Tawreed.BLL.Services.BuyerService;
using Tawreed.BLL.Services.CategoryService;
using Tawreed.BLL.Services.ProductService;
using Tawreed.BLL.Services.RegionService;
using Tawreed.DAL.Data;
using Tawreed.DAL.Repository.BuyerRepo;
using Tawreed.DAL.Repository.CategoryRepo;
using Tawreed.DAL.Repository.ProductRepo;
using Tawreed.DAL.Repository.RegionRepo;

namespace Tawreed.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(op =>
            {
                op.UseSqlServer(connectionString);
            });
            // Add FluentValidation validators for region DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateRegionValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateRegionValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PatchRegionValidator>();
            //Add FluentValidation validators for category DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
            //Add FluentValidation validators for product DTOs
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateProductValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PatchProductValidator>();
            /*------------------------------------------------*/
            // Add other services, repositories, and configurations as needed
            //Region
            builder.Services.AddScoped<IRegionRepo, RegionRepo>();
            builder.Services.AddScoped<IRegionService, RegionService>();
            //Category
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            //Product
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<IBuyerRepo, BuyerRepo>();
            builder.Services.AddScoped<IBuyerService, BuyerService>();

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
