using Core.Repositories;
using Domain;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class FilePizzaRepository : IPizzaRepository
    {
        private readonly InfrastructureConfiguration _configuration;
        private readonly SemaphoreSlim _lock;

        public FilePizzaRepository(IOptions<InfrastructureConfiguration> options)
        {
            _configuration = options.Value;
            _lock = new SemaphoreSlim(1);
        }

        public void SavePizza(Pizza pizza)
        {
            using (var sw = CreateFile())
            {
                sw.WriteLine(pizza.ToString());
            }
        }

        public async Task SavePizzaAsync(Pizza pizza)
        {
            await _lock.WaitAsync();

            using (var sw = CreateFile())
            {
                await sw.WriteLineAsync(pizza.ToString());
            }

            _lock.Release();
        }

        private StreamWriter CreateFile()
        {
            var fileLocation = _configuration.FileLocation + _configuration.FileName;

            if (!File.Exists(fileLocation))
            {
                return File.CreateText(fileLocation);
            }

            return File.AppendText(fileLocation);
        }
    }
}
