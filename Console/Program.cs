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
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var useCase = host.Services.GetService<GeneratePizzasUseCase>();

            //useCase.Execute();
            await useCase.ExecuteAsync();

            await host.StopAsync();
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
