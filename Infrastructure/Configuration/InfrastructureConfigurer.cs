using Core.Repositories;
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
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            return services.AddScoped<IPizzaRepository, FilePizzaRepository>();
        }
    }
}
