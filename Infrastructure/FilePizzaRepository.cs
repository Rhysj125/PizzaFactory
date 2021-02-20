using Core.Repositories;
using Domain;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class FilePizzaRepository : IPizzaRepository
    {
        private readonly string _fileLocation = "Pizzas.txt";

        public FilePizzaRepository()
        {

        }

        public Task SavePizza(Pizza pizza)
        {
            using (var sw = CreateFile())
            {
                return sw.WriteLineAsync(pizza.ToString());
            }
        }

        private StreamWriter CreateFile()
        {
            if (!File.Exists(_fileLocation))
            {
                return File.CreateText(_fileLocation);
            }

            return File.AppendText(_fileLocation);
        }
    }
}
