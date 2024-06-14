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
            Assert.AreEqual(code, currency.Code);
            Assert.AreEqual(name, currency.Name);
            Assert.AreEqual(symbol, currency.Symbol);
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
            Assert.AreEqual("The code  is required. (Parameter 'code')", ex.Message);
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
            Assert.AreEqual("The symbol  is required. (Parameter 'symbol')", ex.Message);
        }
    }
}