using FluentAssertions;
using PriceTracker.Domain;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.UnitTests
{
    public class ProductTest
    {
        [Fact]
        public void UpdatePrice_WithDifferentCurrency_MustReturnInvalidOperationException()
        {
            // Arrange
            var eurosPrice = Price.EnEuros(100);
            var product = new Product("Teclado Mecánico", "https://tienda.com/teclado", eurosPrice);
            var dollarsPrice = new Price(100, "USD");

            // Act
            Action act = () => product.UpdatePrice(dollarsPrice);

            // Assert
            act.Should().Throw<InvalidOperationException>()
               .WithMessage("Price need to have same currency");
        }

        [Fact]
        public void UpdatePrice_WichValidPrice_MustModifyPriceAndUpdateDate()
        {
            // Arrange
            var initialPrice = Price.EnEuros(100);
            var product = new Product("Teclado Mecánico", "https://tienda.com/teclado", initialPrice);
            var newPrice = Price.EnEuros(85);

            // Act
            product.UpdatePrice(newPrice);

            // Assert
            product.CurrentPrice.Should().Be(newPrice);
            product.LastUpdate.Should().NotBe(null);
            product.LastUpdate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(2));
        }
    }
}
