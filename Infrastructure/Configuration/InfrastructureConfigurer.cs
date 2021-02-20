using Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class InfrastructureConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInfrastructureDependancies(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("Configuration/InfrastructureSettings.json", optional: false, reloadOnChange: true).Build();

            return services
                .AddScoped<IPizzaRepository, FilePizzaRepository>()
                .Configure<InfrastructureConfiguration>(options => config.GetSection("InfrastructureSettings").Bind(options));
        }
    }
}
