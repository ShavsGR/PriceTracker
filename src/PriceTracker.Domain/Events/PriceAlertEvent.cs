using PriceTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain.Events
{
    public class PriceAlertEvent : IDomainEvent
    {
        public Guid AlertGuid { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public Precio OriginalPrice { get; set; }
        public Precio CurrentPrice { get; set; }
        public DateTime EventDate { get; set; }

        public PriceAlertEvent(
            Guid alertId,
            Guid productId,
            Guid userId,
            Precio originalPrice,
            Precio currentPrice)
        {
            AlertGuid = alertId;
            ProductId = productId;
            UserId = userId;
            OriginalPrice = originalPrice;
            CurrentPrice = currentPrice;
            EventDate = DateTime.Now;
        }
    }
}
