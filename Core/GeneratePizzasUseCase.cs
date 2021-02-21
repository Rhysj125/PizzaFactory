using Core.Configuration;
using Core.Factories;
using Core.Repositories;
using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// A <see cref="GeneratePizzasUseCase"/>.
    /// </summary>
    public class GeneratePizzasUseCase
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaFactory _pizzaFactory;
        private readonly CoreConfiguration _configuration;

        /// <summary>
        /// Creates an insatnce of the <see cref="GeneratePizzasUseCase"/>
        /// </summary>
        /// <param name="pizzaRepository">The <see cref="IPizzaRepository"/> to use.</param>
        /// <param name="pizzaFactory">The <see cref="IPizzaFactory"/> to use.</param>
        /// <param name="options">The <see cref="IOptions{CoreConfiguration}"/> to use.</param>
        public GeneratePizzasUseCase(IPizzaRepository pizzaRepository, IPizzaFactory pizzaFactory, IOptions<CoreConfiguration> options)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            _pizzaFactory = pizzaFactory ?? throw new ArgumentNullException(nameof(pizzaFactory));
            _configuration = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Execute the <see cref="GeneratePizzasUseCase"/>.
        /// </summary>
        public void Execute()
        {
            // Create 50 random pizzas
            var pizzas = _pizzaFactory.GeneratePizzas();

            // Cook pizzas with interval
            foreach(var pizza in pizzas)
            {
                pizza.Cook(_configuration.BasePizzaCookingTime);

                _pizzaRepository.SavePizza(pizza);

                Thread.Sleep(_configuration.CookingInterval);
            }
        }

        /// <summary>
        /// Execute the <see cref="GeneratePizzasUseCase"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        public async Task ExecuteAsync()
        {
            var pizzas = _pizzaFactory.GeneratePizzas();
            var pizzaCookingTasks = new List<Task>();

            // Cook pizzas with interval
            foreach (var pizza in pizzas)
            {
                pizzaCookingTasks.Add(CookAndSave(pizza));

                Thread.Sleep(_configuration.CookingInterval);
            }

            await Task.WhenAll(pizzaCookingTasks);
        }

        private async Task CookAndSave(Pizza pizza)
        {
            await pizza.CookAsync(_configuration.BasePizzaCookingTime);
            await _pizzaRepository.SavePizzaAsync(pizza);
        }
    }
}
