using Domain;
using NUnit.Framework;
using System;

namespace DomainTests
{
    [TestFixture]
    public class PizzaTests
    {
        private Topping _topping;
        private PizzaBase _pizzaBase;

        [SetUp]
        public void Setup()
        {
            _topping = new Topping("Test Topping");
            _pizzaBase = new PizzaBase("Test Base", 1);
        }

        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenBaseIsNull()
        {
            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Pizza(null, _topping));
        }

        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenToppingIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Pizza(_pizzaBase, null));
        }

        [Test]
        public void PizzaToStringHasBaseAndToppingName()
        {
            // Arrange
            var pizza = new Pizza(_pizzaBase, _topping);
            var expectedPizzaName = $"{_pizzaBase.Name} - {_topping.Name}";

            // Act
            var pizzaString = pizza.ToString();

            // Assert
            Assert.AreEqual(expectedPizzaName ,pizzaString);
        }
    }
}
