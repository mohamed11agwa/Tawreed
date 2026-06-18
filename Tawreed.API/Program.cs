using FluentValidation;
using Tawreed.API.Extensions;
using Tawreed.API.Registration;
using Tawreed.API.Validators;
using Tawreed.BLL.Dtos.Category;
using Tawreed.BLL.Dtos.Product;
using Tawreed.BLL.Dtos.Reigon;
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
        public  static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddDependencies(builder.Configuration);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

          
            /*------------------------------------------------*/
            // Add other services, repositories, and configurations as needed


            var app = builder.Build();
            await app.SeedRolesAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.Map("/home", () =>
            {
                return Results.Ok("hello");
            });
            app.Run();
        }
    }
}
