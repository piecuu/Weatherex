using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Weatherex.Infrastructure.Persistence;

namespace Weatherex.Infrastructure.Identity
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityExtension(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
