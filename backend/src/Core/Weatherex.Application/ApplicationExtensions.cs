using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Weatherex.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationexstension(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
