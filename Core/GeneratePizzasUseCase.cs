using Core.Configuration;
using Core.Repositories;
using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
        public void Execute()
        {
            // Create 50 random pizzas
            var pizzas = GeneratePizzas();

            // Cook pizzas with interval
            foreach(var pizza in pizzas)
            {
                pizza.Cook(_pizzaConfiguration.BasePizzaCookingTime);

                _pizzaRepository.SavePizza(pizza);

                Thread.Sleep(_pizzaConfiguration.CookingInterval);
            }
        }

        private IEnumerable<Pizza> GeneratePizzas()
        {
            var bases = _pizzaConfiguration.BaseConfigurations;
            var toppings = _pizzaConfiguration.ToppingConfigurations;

            var rnd = new Random();

            for (int i = 0; i < _pizzaConfiguration.PizzasToMake; i++)
            {
                var pizzaBase = bases[rnd.Next(bases.Count())];
                var topping = toppings[rnd.Next(toppings.Count())];

                yield return new Pizza(CreatePizzaBase(pizzaBase), CreateTopping(topping));
            }
        }

        private PizzaBase CreatePizzaBase(BaseConfiguration baseConfiguration)
            => new PizzaBase(baseConfiguration.Name, baseConfiguration.CookingMultiplier);

        private Topping CreateTopping(ToppingConfiguration toppingConfiguration)
            => new Topping(toppingConfiguration.Name);
    }
}
