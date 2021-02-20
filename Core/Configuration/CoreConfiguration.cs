using Domain;
using System.Collections.Generic;

namespace Core.Configuration
{
    /// <summary>
    /// The configuration for Pizzas.
    /// </summary>
    public class CoreConfiguration
    {
        /// <summary>
        /// A list of possible pizza bases.
        /// </summary>
        public IList<PizzaBase> PizzaBases { get; set; }

        /// <summary>
        /// A list of possible pizza toppings.
        /// </summary>
        public IList<Topping> Toppings { get; set; }

        /// <summary>
        /// The number of pizzas to generate
        /// </summary>
        public int PizzasToMake { get; set; }

        /// <summary>
        /// The baseline cooking time for a pizza in milliseconds
        /// </summary>
        public int BasePizzaCookingTime { get; set; }

        /// <summary>
        /// The time between cooking in milliseconds 
        /// </summary>
        public int CookingInterval { get; set; }
    }
}
