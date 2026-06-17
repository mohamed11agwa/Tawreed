using Tawreed.API.Registration.Sub;

namespace Tawreed.API.Registration
{
    public  static class MainRegistrations
    {
        public static IServiceCollection AddApplicationServices(
      this IServiceCollection services)
        {
            services.AddValidatorsRegistration();

            // services.AddRepositoryRegistration();
            // services.AddBusinessServicesRegistration();
            // services.AddAuthenticationRegistration();
            // services.AddSwaggerRegistration();

            return services;
        }
    }
}
