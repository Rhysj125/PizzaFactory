using Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    /// <summary>
    /// Extension methods for configurating infrastructure dependancies.
    /// </summary>
    public static class InfrastructureConfigurer
    {
        /// <summary>
        /// Configure the infrastructure dependancies.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register the dependancies too.</param>
        /// <returns>The <see cref="IServiceCollection"/> to support a fluent api.</returns>
        public static IServiceCollection ConfigureInfrastructureDependancies(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("Configuration/InfrastructureSettings.json", optional: false, reloadOnChange: true).Build();

            return services
                .AddTransient<IPizzaRepository, FilePizzaRepository>()
                .Configure<InfrastructureConfiguration>(options => config.GetSection("InfrastructureSettings").Bind(options));
        }
    }
}
