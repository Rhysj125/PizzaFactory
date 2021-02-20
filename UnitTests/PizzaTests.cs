using Domain;
using NUnit.Framework;
using System;

namespace DomainTests
{
    [TestFixture]
    public class PizzaTests
    {
        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenBaseIsNull()
        {
            //Arrange
            var topping = new Topping("Test");

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Pizza(null, topping));
        }

        [Test]
        public void PizzaCtorThrowArgumentNullExceptionWhenToppingIsNull()
        {
            //Arrange
            var pizzaBase = new PizzaBase("Test", 1);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Pizza(pizzaBase, null));
        }
    }
}
