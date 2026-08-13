using FluentAssertions;
using PriceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.UnitTests
{
    public class PriceTests
    {
        [Fact]
        public void Create_WithValidPriceAndCurrency_MustCreateObjectCorrectly()
        {
            // Arrange
            decimal price = 99.99m;
            string currency = "EUR";

            // Act
            var precio = new Precio(price, currency);

            // Assert
            precio.Price.Should().Be(99.99m);
            precio.Currency.Should().Be("EUR"); // Verifica la conversión a mayúsculas
        }

        [Fact]
        public void Create_WithNegativePrice_MustReturnArgumentException()
        {
            // Act
            Action act = () => new Precio(-10.00m, "EUR");

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Cant have negative price");
        }

        [Fact]
        public void TwoPricesWithSamePriceAndCurrency_MustBeTheSame()
        {
            // Arrange & Act
            var price1 = Precio.EnEuros(50);
            var price2 = Precio.EnEuros(50);

            // Assert
            price1.Should().Be(price2); // Comprueba la igualdad por valor propia del record
        }
    }
}
