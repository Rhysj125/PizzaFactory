using System;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// A <see cref="Topping"/>.
    /// </summary>
    public class Topping
    {

        /// <summary>
        /// The name of the topping.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The amount of time taken to cook the topping in milliseconds.
        /// </summary>
        public int CookTime
        {
            get
            {
                return Name.Replace(" ", "").Count() * 100;
            }
        }

        /// <summary>
        /// Initalises an instance of <see cref="Topping"/>.
        /// </summary>
        /// <param name="name"></param>
        public Topping(string name)
        {
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentNullException($"{nameof(name)} cannot be null");
        }
    }
}
