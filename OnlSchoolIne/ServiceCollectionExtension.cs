using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnSchoolLine.Services;

namespace OnSchoolLine
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCollectionService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            return services;    
        }
    }
}
