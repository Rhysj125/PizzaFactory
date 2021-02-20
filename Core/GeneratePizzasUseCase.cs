using Core.Configuration;
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
        private readonly CoreConfiguration _pizzaConfiguration;

        /// <summary>
        /// Creates an insatnce of the <see cref="GeneratePizzasUseCase"/>
        /// </summary>
        /// <param name="pizzaRepository">The <see cref="IPizzaRepository"/> to use.</param>
        /// <param name="pizzaOptions">The <see cref="IOptions{PizzaConfiguration}"/> to use.</param>
        public GeneratePizzasUseCase(IPizzaRepository pizzaRepository, IOptions<CoreConfiguration> pizzaOptions)
        {
            _pizzaRepository = pizzaRepository;
            _pizzaConfiguration = pizzaOptions.Value;
        }

        /// <summary>
        /// Execute the <see cref="GeneratePizzasUseCase"/>.
        /// </summary>
        public async Task Execute()
        {
            // Create 50 random pizzas
            var pizzas = GeneratePizzas();

            // Cook pizzas with interval
            foreach(var pizza in pizzas)
            {
                pizza.Cook(_pizzaConfiguration.BasePizzaCookingTime);

                Thread.Sleep(_pizzaConfiguration.CookingInterval);

                await _pizzaRepository.SavePizza(pizza);
            }
        }

        private IEnumerable<Pizza> GeneratePizzas()
        {
            var bases = _pizzaConfiguration.PizzaBases;
            var toppings = _pizzaConfiguration.Toppings;

            for(int i = 0; i < _pizzaConfiguration.PizzasToMake; i++)
            {
                var rnd = new Random();

                var pizzaBase = bases[rnd.Next(bases.Count - 1)];
                var topping = toppings[rnd.Next(toppings.Count - 1)];

                yield return new Pizza(pizzaBase, topping);
            }
        }
    }
}
