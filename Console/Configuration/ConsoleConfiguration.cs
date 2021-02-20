using Core.Configuration;
using Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Configuration
{
    internal static class ConsoleConfiguration
    {
        public static IServiceCollection ConfigureDependancies(this IServiceCollection services)
        {
            return services
                .ConfigureCoreDependancies()
                .ConfigureInfrastructureDependancies();
        }
    }
}
