using Domain;

namespace Core.Configuration
{
    internal class PizzaConfiguration
    {
        public PizzaBase[] PizzaBases { get; set; }

        public string[] Toppings { get; set; }
    }
}
