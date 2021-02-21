using Core.Configuration;
using Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CoreTests")]

namespace Core.Factories
{
    internal class PizzaFactory : IPizzaFactory
    {
        private readonly CoreConfiguration _configuration;

        public PizzaFactory(IOptions<CoreConfiguration> options)
        {
            _configuration = options.Value ?? throw new ArgumentNullException($"{nameof(options.Value)} cannot be null.");
        }

        public IEnumerable<Pizza> GeneratePizzas()
        {
            var bases = _configuration.BaseConfigurations;
            var toppings = _configuration.ToppingConfigurations;

            var rnd = new Random();

            for (int i = 0; i < _configuration.PizzasToMake; i++)
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
