using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weatherex.Application.Interfaces;
using Weatherex.Infrastructure.Auth;
using Weatherex.Infrastructure.Identity;
using Weatherex.Infrastructure.Persistence;
using Weatherex.Infrastructure.Services;

namespace Weatherex.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextExtension(configuration);
            services.AddIdentityExtension();
            services.AddAuthExtensions(configuration);

            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
