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
            services.ConfigureOptions<PizzaConfiguration>();

            return services;
        }
    }
}
