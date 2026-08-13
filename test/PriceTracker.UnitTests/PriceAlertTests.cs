using FluentAssertions;
using PriceTracker.Domain;
using PriceTracker.Domain.Entities;
using PriceTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.UnitTests
{
    public class PriceAlertTests
    {
        [Fact]
        public void EvaluateAndSend_WhenPriceIsLessThanCurrent_MustBeSentAndRegistered()
        {
            // Arrange
            var targetPrice = Precio.EnEuros(100);
            var alert = new PriceAlert(Guid.NewGuid(), Guid.NewGuid(), targetPrice);
            var newPrice = Precio.EnEuros(90);

            // Act
            bool resultado = alert.EvaluateAndSend(newPrice);

            // Assert
            resultado.Should().BeTrue();
            alert.Active.Should().BeFalse();
            alert.AlertDate.Should().NotBeNull();

            // We should verify the event was added
            alert.DomainEvents.Should().HaveCount(1);
            var @event = alert.DomainEvents.First().Should().BeOfType<PriceAlertEvent>().Subject;
            @event.CurrentPrice.Should().Be(newPrice);
            @event.OriginalPrice.Should().Be(targetPrice);
        }

        [Fact]
        public void EvaluateAndSend_WhenPriceIsHigher_ShouldNotBeSend()
        {
            // Arrange
            var targetPrice = Precio.EnEuros(100);
            var alert = new PriceAlert(Guid.NewGuid(), Guid.NewGuid(), targetPrice);
            var higherPrice = Precio.EnEuros(110);

            // Act
            bool result = alert.EvaluateAndSend(higherPrice);

            // Assert
            result.Should().BeFalse();
            alert.Active.Should().BeTrue();
            alert.AlertDate.Should().BeNull();
            alert.DomainEvents.Should().BeEmpty();
        }
    }
}
