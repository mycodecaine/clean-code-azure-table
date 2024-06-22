using NUnit.Framework;
using Cdcn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Domain.Entities.Tests
{
    [TestFixture()]
    public class CurrencyTests
    {
        [Test]
        public void Currency_ShouldInitializeProperties()
        {
            // Arrange
            var code = "USD";
            var name = "United States Dollar";
            var symbol = "$";

            // Act
            var currency = new Currency(code, name, symbol);

            // Assert
            Assert.That(currency.Code, Is.EqualTo(code));
            Assert.That(currency.Name, Is.EqualTo(name));
            Assert.That(currency.Symbol, Is.EqualTo(symbol));
        }

        [Test]
        public void Currency_ShouldThrowException_WhenCodeIsEmpty()
        {
            // Arrange
            var code = "";
            var name = "United States Dollar";
            var symbol = "$";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Currency(code, name, symbol));
            Assert.That(ex.Message, Is.EqualTo("The code  is required. (Parameter 'code')"));
        }

        [Test]
        public void Currency_ShouldThrowException_WhenSymbolIsEmpty()
        {
            // Arrange
            var code = "USD";
            var name = "United States Dollar";
            var symbol = "";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Currency(code, name, symbol));
            Assert.That(ex.Message, Is.EqualTo("The symbol  is required. (Parameter 'symbol')"));
        }
    }
}