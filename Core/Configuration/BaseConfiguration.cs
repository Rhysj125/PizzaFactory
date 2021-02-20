namespace Core
{
    /// <summary>
    /// A <see cref="BaseConfiguration"/>.
    /// </summary>
    public class BaseConfiguration
    {

        /// <summary>
        /// The name of the pizza base.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cooking time multiplier.
        /// </summary>
        public decimal CookingMultiplier { get; set; }
    }
}
