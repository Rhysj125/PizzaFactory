using Core.Repositories;

namespace Core
{
    /// <summary>
    /// A <see cref="GeneratePizzasUseCase"/>.
    /// </summary>
    public class GeneratePizzasUseCase
    {
        private readonly IPizzaRepository _pizzaRepository;

        /// <summary>
        /// Creates an insatnce of the <see cref="GeneratePizzasUseCase"/>
        /// </summary>
        /// <param name="pizzaRepository">The <see cref="IPizzaRepository"/> to use.</param>
        public GeneratePizzasUseCase(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        /// <summary>
        /// Execute the <see cref="GeneratePizzasUseCase"/>.
        /// </summary>
        public void Execute()
        {
            // Create 50 random pizzas

            // Cook pizzas with interval

            // Write to output file
        }
    }
}
