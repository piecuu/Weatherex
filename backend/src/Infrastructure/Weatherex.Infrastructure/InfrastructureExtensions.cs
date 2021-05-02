using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weatherex.Infrastructure.Persistence;

namespace Weatherex.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextExtension(configuration);

            return services;
        }
    }
}
