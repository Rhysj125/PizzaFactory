using Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PizzaFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(_, services =>
                {
                    services.ConfigureDependancies()
                });
        }

        static IServiceCollection ConfigureDependancies(this IServiceCollection services)
        {
            return services.ConfigureCoreDependancies();
        }
    }
}
