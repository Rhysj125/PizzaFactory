using Domain;
using NUnit.Framework;
using System;

namespace DomainTests
{
    [TestFixture]
    public class PizzaBaseTests
    {
        [Test]
        public void PizzaBaseCtorThrowsNullExceptionWhenNameIsNull()
        {
            // Act & Assert
            var error = Assert.Throws<ArgumentNullException>(() => new PizzaBase(null, 1));
            Assert.AreEqual("name", error.ParamName);
        }
    }
}
