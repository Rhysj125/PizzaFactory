using Domain;
using System.Collections.Generic;

namespace Core.Factories
{
    /// <summary>
    /// A factory for creating <see cref="Pizza"/>'s
    /// </summary>
    public interface IPizzaFactory
    {
        /// <summary>
        /// Generate <see cref="Pizza"/>'s from configuration.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pizza> GeneratePizzas();
    }
}