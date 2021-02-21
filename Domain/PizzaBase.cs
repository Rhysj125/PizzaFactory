using System;

namespace Domain
{
    /// <summary>
    /// A <see cref="PizzaBase"/>.
    /// </summary>
    public class PizzaBase
    {

        /// <summary>
        /// The name of the pizza base.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The cooking time multiplier.
        /// </summary>
        public decimal CookingMultiplier { get; private set; }

        /// <summary>
        /// Creates an instance of <see cref="PizzaBase"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cookingMultiplier"></param>
        public PizzaBase(string name, decimal cookingMultiplier)
        {
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException(nameof(name));
            CookingMultiplier = cookingMultiplier;
        }
    }
}
