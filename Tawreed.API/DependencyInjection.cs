using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using System.Text;
using Tawreed.BLL.Contracts.Authentication;
using Tawreed.BLL.Services.AuthService;
using Tawreed.BLL.Services.CategoryService;
using Tawreed.BLL.Services.ProductService;
using Tawreed.BLL.Services.RegionService;
using Tawreed.DAL.Data;
using Tawreed.DAL.Models;
using Tawreed.DAL.Repository.CategoryRepo;
using Tawreed.DAL.Repository.ProductRepo;
using Tawreed.DAL.Repository.RegionRepo;

namespace Tawreed.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your service registrations here

            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("connection string 'DefaultConnection' Not Found");
            
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddControllers();

            services.AddAuthConfig(configuration);


            services.AddFluentValidationConfig();

           services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IRegionRepo, RegionRepo>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }




        private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            var assemblies = new[]
                {
                    Assembly.GetExecutingAssembly(),                  // الـ API
                    typeof(RegisterSupplierRequestValidator).Assembly,
                    typeof(RegisterBuyerRequestValidator).Assembly  ,
                    typeof(LoginRequestValidator).Assembly  // الـ BLL
                };
            services.AddFluentValidationAutoValidation()
                //.AddValidatorsFromAssemblyContaining<RegisterBuyerRequestValidator>();
                .AddValidatorsFromAssemblies(assemblies);
                //.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }


        private static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddOptions<JwtOptions>()
                .Bind(configuration.GetSection(JwtOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var jwtOptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.Key!)),
                    ValidIssuer = jwtOptions?.Issuer,
                    ValidAudience = jwtOptions?.Audience,
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;

            });

            return services;
        }
    }
}
