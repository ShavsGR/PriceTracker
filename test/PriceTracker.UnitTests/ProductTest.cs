using FluentAssertions;
using PriceTracker.Domain;
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
            var eurosPrice = Precio.EnEuros(100);
            var product = new Producto("Teclado Mecánico", "https://tienda.com/teclado", eurosPrice);
            var dollarsPrice = new Precio(100, "USD");

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
            var initialPrice = Precio.EnEuros(100);
            var product = new Producto("Teclado Mecánico", "https://tienda.com/teclado", initialPrice);
            var newPrice = Precio.EnEuros(85);

            // Act
            product.UpdatePrice(newPrice);

            // Assert
            product.CurrentPrice.Should().Be(newPrice);
            product.LastUpdate.Should().NotBe(null);
            product.LastUpdate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(2));
        }
    }
}
