using Microsoft.Extensions.DependencyInjection;
using Weatherex.Application.Interfaces;

namespace Weatherex.Infrastructure.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();

            return services; 
        }
    }
}
