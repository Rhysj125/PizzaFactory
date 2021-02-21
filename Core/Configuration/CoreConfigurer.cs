using Core.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration
{
    /// <summary>
    /// Extension methods for configurating core dependancies.
    /// </summary>
    public static class CoreConfigurer
    {

        /// <summary>
        /// Configure the core dependancies.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register the dependancies too.</param>
        /// <returns>The <see cref="IServiceCollection"/> to support a fluent api.</returns>
        public static IServiceCollection ConfigureCoreDependancies(this IServiceCollection services) 
        {
            var config = new ConfigurationBuilder().AddJsonFile("Configuration/CoreSettings.json", optional: false, reloadOnChange: true).Build();

            return services
                .AddScoped<GeneratePizzasUseCase>()
                .AddScoped<IPizzaFactory, PizzaFactory>()
                .Configure<CoreConfiguration>(options => config.GetSection("CoreSettings").Bind(options));
        }
    }
}
