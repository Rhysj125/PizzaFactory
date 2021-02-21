using System;
using System.Threading;
using System.Threading.Tasks;

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
            Base = pizzaBase ?? throw new ArgumentNullException(nameof(pizzaBase));
            Topping = topping ?? throw new ArgumentNullException(nameof(topping));
        }

        /// <summary>
        /// Cook the pizza
        /// </summary>
        /// <param name="baseCookTime">The base cooking time of a pizza base.</param>
        public void Cook(int baseCookTime)
        {
            if (!IsCooked)
            {
                var totalCookTime = baseCookTime * Base.CookingMultiplier;

                totalCookTime += Topping.CookTime;

                Thread.Sleep(Convert.ToInt32(totalCookTime));

                IsCooked = false;
            }
        }

        /// <summary>
        /// Cook the pizza asynchornously.
        /// </summary>
        /// <param name="baseCookTime">The base cooking time of a pizza base.</param>
        /// <returns>A <see cref="Task"/></returns>
        public Task CookAsync(int baseCookTime)
        {
            if (!IsCooked)
            {
                var totalCookTime = baseCookTime * Base.CookingMultiplier;

                totalCookTime += Topping.CookTime;

                IsCooked = false;

                return Task.Delay(Convert.ToInt32(totalCookTime));
            }

            return Task.FromResult(0);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Base.Name} - {Topping.Name}";
        }
    }
}
