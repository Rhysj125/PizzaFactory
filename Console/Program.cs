using Console.Configuration;
using Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace PizzaFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var useCase = host.Services.GetService<GeneratePizzasUseCase>();

            useCase.Execute();

            return host.StopAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.ConfigureDependancies();
                });
        }
    }
}
