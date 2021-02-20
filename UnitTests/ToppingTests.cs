using Domain;
using NUnit.Framework;
using System;

namespace DomainTests
{
    public class ToppingTests
    {
        [Test]
        public void ToppingCtorThrowsArgumentNullExceptionWhenNameIsNull()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Topping(null));
        }

        [TestCase("Pepperoni", 9)]
        [TestCase("Cheese", 6)]
        [TestCase("Ham & Pineapple", 13)]
        public void ToppingCookTimeReturnCorrectValue(string name, int expectedValue)
        {
            // Arrange
            var topping = new Topping(name);

            // Act & Assert
            Assert.AreEqual(expectedValue, topping.CookTime);
        }
    }
}