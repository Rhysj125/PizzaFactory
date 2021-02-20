using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Configuration
{
    internal static class APIConfiguration
    {
        public static IServiceCollection ConfigureDependancies(this IServiceCollection services)
        {
            return services.ConfigureCoreDependancies();
        }
    }
}
