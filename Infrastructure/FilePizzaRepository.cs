using Core.Repositories;
using Domain;
using Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace Infrastructure
{
    internal class FilePizzaRepository : IPizzaRepository
    {
        private readonly InfrastructureConfiguration _configuration;

        public FilePizzaRepository(IOptions<InfrastructureConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SavePizza(Pizza pizza)
        {
            using (var sw = CreateFile())
            {
                sw.WriteLine(pizza.ToString());
            }
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
