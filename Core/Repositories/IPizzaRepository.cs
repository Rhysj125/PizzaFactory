using Domain;
using System.Threading.Tasks;

namespace Core.Repositories
{
    /// <summary>
    /// An <see cref="IPizzaRepository"/>.
    /// </summary>
    public interface IPizzaRepository
    {
        /// <summary>
        /// Save a pizza to the repository.
        /// </summary>
        /// <param name="pizza">The <see cref="Pizza"/> to save.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        void SavePizza(Pizza pizza);
    }
}
