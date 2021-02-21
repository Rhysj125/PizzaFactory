using Core;
using Core.Configuration;
using Core.Factories;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace InfrastructureTests
{
    public class PizzaFactoryTests
    {
        private Mock<IOptions<CoreConfiguration>> _mockOptions;


        [SetUp]
        public void Setup()
        {
            _mockOptions = new Mock<IOptions<CoreConfiguration>>();
        }

        [TestCase(10)]
        [TestCase(50)]
        public void FactoryGeneratesNumberPizzasSpecifiedInConfig(int numberOfPizzasToMake)
        {
            // Arrange
            var config = new CoreConfiguration
            {
                PizzasToMake = numberOfPizzasToMake,
                BaseConfigurations = new[]
                {
                    new BaseConfiguration
                    {
                        Name = "Test Base",
                        CookingMultiplier = 1
                    }
                },
                ToppingConfigurations = new[]
                {
                    new ToppingConfiguration
                    {
                        Name = "Test Topping"
                    }
                }
            };

            _mockOptions.Setup(x => x.Value).Returns(config);
            var pizzaFactory = new PizzaFactory(_mockOptions.Object);

            // Act
            var pizzas = pizzaFactory.GeneratePizzas();

            // Assert
            Assert.AreEqual(numberOfPizzasToMake, pizzas.Count());
        }

        [Test]
        public void FactoryGeneratesPizzaWithConfig()
        {
            var baseName = "Test Base";
            var cookingMultiplier = 1;
            var toppingName = "Test Topping";


            var config = new CoreConfiguration
            {
                PizzasToMake = 1,
                BaseConfigurations = new[]
                {
                    new BaseConfiguration
                    {
                        Name = baseName,
                        CookingMultiplier = cookingMultiplier
                    }
                },
                ToppingConfigurations = new[]
                {
                    new ToppingConfiguration
                    {
                        Name = toppingName
                    }
                }
            };

            _mockOptions.Setup(x => x.Value).Returns(config);
            var pizzaFactory = new PizzaFactory(_mockOptions.Object);

            // Act
            var pizzas = pizzaFactory.GeneratePizzas();

            // Assert
            var pizza = pizzas.FirstOrDefault();

            Assert.IsNotNull(pizza);
            Assert.AreEqual(baseName, pizza.Base.Name);
            Assert.AreEqual(cookingMultiplier, pizza.Base.CookingMultiplier);
            Assert.AreEqual(toppingName, pizza.Topping.Name);
        }
    }
}