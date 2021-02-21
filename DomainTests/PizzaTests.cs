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

        private Pizza _sut;

        [SetUp]
        public void Setup()
        {
            _topping = new Topping("Test Topping");
            _pizzaBase = new PizzaBase("Test Base", 1);

            _sut = new Pizza(_pizzaBase, _topping);
        }

        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenBaseIsNull()
        {
            // Act && Assert
            var error = Assert.Throws<ArgumentNullException>(() => new Pizza(null, _topping));
            Assert.AreEqual("pizzaBase", error.ParamName);
        }

        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenToppingIsNull()
        {
            // Act & Assert
            var error = Assert.Throws<ArgumentNullException>(() => new Pizza(_pizzaBase, null));
            Assert.AreEqual("topping", error.ParamName);
        }

        [Test]
        public void PizzaToStringHasBaseAndToppingName()
        {
            // Arrange
            var expectedPizzaName = $"{_pizzaBase.Name} - {_topping.Name}";

            // Act
            var pizzaString = _sut.ToString();

            // Assert
            Assert.AreEqual(expectedPizzaName, pizzaString);
        }
    }
}
