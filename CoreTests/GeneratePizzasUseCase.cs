using Core;
using Core.Configuration;
using Core.Factories;
using Core.Repositories;
using Domain;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;

namespace InfrastructureTests
{
    public class GeneratePizzaUseCaseTests
    {
        private Mock<IPizzaRepository> _mockPizzaRepository;
        private Mock<IPizzaFactory> _mockPizzaFactory;
        private Mock<IOptions<CoreConfiguration>> _mockOptions;

        private GeneratePizzasUseCase _sut;

        [SetUp]
        public void Setup()
        {
            _mockPizzaRepository = new Mock<IPizzaRepository>();
            _mockPizzaFactory = new Mock<IPizzaFactory>();
            _mockOptions = new Mock<IOptions<CoreConfiguration>>();

            var coreConfiguration = new CoreConfiguration();

            _mockOptions.Setup(x => x.Value).Returns(coreConfiguration);

            _sut = new GeneratePizzasUseCase(_mockPizzaRepository.Object, _mockPizzaFactory.Object, _mockOptions.Object);
        }

        [Test]
        public void CtorThrowsExceptionWhenPizzaRepositoryIsNull()
        {
            // Act & Assert
            var error = Assert.Throws<ArgumentNullException>(() => new GeneratePizzasUseCase(null, _mockPizzaFactory.Object, _mockOptions.Object));
            Assert.AreEqual("pizzaRepository", error.ParamName);
        }

        [Test]
        public void CtorThrowsExceptionWhenPizzaFactoryIsNull()
        {
            // Act & Assert
            var error = Assert.Throws<ArgumentNullException>(() => new GeneratePizzasUseCase(_mockPizzaRepository.Object, null, _mockOptions.Object));
            Assert.AreEqual("pizzaFactory", error.ParamName);
        }

        [Test]
        public void CtorThrowsExceptionWhenCoreConfigurationIsNull()
        {
            // Act & Assert
            var error = Assert.Throws<ArgumentNullException>(() => new GeneratePizzasUseCase(_mockPizzaRepository.Object, _mockPizzaFactory.Object, null));
            Assert.AreEqual("options", error.ParamName);
        }

        [Test]
        public void ExecuteThrowsExceptionWhenFactoryThrows()
        {
            // Arrange
            _mockPizzaFactory.Setup(x => x.GeneratePizzas()).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Execute());
        }

        [Test]
        public void ExecuteThrowsExceptionWhenRepositoryThrows()
        {
            // Arrange
            var pizzaBase = new PizzaBase("Test Base", 0);
            var topping = new Topping("Test Topping");
            var pizza = new Pizza(pizzaBase, topping);

            _mockPizzaFactory.Setup(x => x.GeneratePizzas()).Returns(new[] { pizza });
            _mockPizzaRepository.Setup(x => x.SavePizza(It.IsAny<Pizza>())).Throws(new Exception());

            // Act & Assert
            Assert.Throws<Exception>(() => _sut.Execute());
        }

        [Test]
        public void ExcuteSavesPizzaOnceCooked()
        {
            // Arrange
            var pizzaBase = new PizzaBase("Test Base", 0);
            var topping = new Topping("Test Topping");
            var pizza = new Pizza(pizzaBase, topping);

            _mockPizzaFactory.Setup(x => x.GeneratePizzas()).Returns(new[] { pizza });

            // Act
            _sut.Execute();

            // Assert
            _mockPizzaRepository.Verify(x => x.SavePizza(It.IsAny<Pizza>()), Times.Once);
        }
    }
}