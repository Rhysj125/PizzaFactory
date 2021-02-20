using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configuration
{
    /// <summary>
    /// Extension methods for configurating domain dependancies.
    /// </summary>
    public static class CoreConfigurer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureCoreDependancies(this IServiceCollection services) 
        {
            var config = new ConfigurationBuilder().AddJsonFile("Configuration/CoreSettings.json", optional: false, reloadOnChange: true).Build();

            return services
                .AddScoped<GeneratePizzasUseCase>()
                .Configure<CoreConfiguration>(options => config.GetSection("CoreSettings").Bind(options));
        }
    }
}
