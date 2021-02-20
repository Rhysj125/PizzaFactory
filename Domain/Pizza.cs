using System;
using System.Threading;

namespace Domain
{
    /// <summary>
    /// A <see cref="Pizza"/>.
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// The <see cref="Base"/> for the pizza.
        /// </summary>
        public PizzaBase Base { get; private set; }

        /// <summary>
        /// The <see cref="Topping"/> for a pizza
        /// </summary>
        public Topping Topping { get; private set; }

        private bool IsCooked = false;

        /// <summary>
        /// Initalises an instance of <see cref="Pizza"/>.
        /// </summary>
        /// <param name="pizzaBase">The <see cref="PizzaBase"/> to use.</param>
        /// <param name="topping">The <see cref="Topping"/> to use.</param>
        public Pizza(PizzaBase pizzaBase, Topping topping)
        {
            Base = pizzaBase ?? throw new ArgumentNullException($"{nameof(pizzaBase)} cannot be null");
            Topping = topping ?? throw new ArgumentNullException($"{nameof(topping)} cannot be null");
        }

        /// <summary>
        /// Cook the pizza
        /// </summary>
        public void Cook(int baseCookTime)
        {
            if (!IsCooked)
            {
                var totalCookTime = baseCookTime * Base.CookingMultiplier;

                totalCookTime += Topping.CookTime;

                Thread.Sleep(Convert.ToInt32(totalCookTime));
            }
        }
    }
}
