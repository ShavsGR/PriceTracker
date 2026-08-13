using PriceTracker.Domain.Common;
using PriceTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain.Entities
{
    public class PriceAlert
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public List<IDomainEvent> DomainEvents => _domainEvents;
        

        public Guid Id {get; private set; }
        public Guid ProductId {get; private set; }
        public Guid UserId {get; private set; }
        public Precio TargetPrice {get; private set; }
        public bool Active {get; private set; }
        public DateTime? AlertDate {get; private set; }
        public DateTime PublishDate {get; private set; }

        public PriceAlert(Guid productId, Guid userId,Precio targetPrice)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("Product Id must be included.", nameof(productId));

            if (userId == Guid.Empty)
                throw new ArgumentException("User id is mandatory.", nameof(userId));

            Id = Guid.NewGuid();
            ProductId = productId;
            UserId = userId;
            TargetPrice = targetPrice ?? throw new ArgumentNullException(nameof(targetPrice));
            Active = true;
            PublishDate = DateTime.Now;
        }

        public bool EvaluateAndSend(Precio newPrice)
        {
            ArgumentNullException.ThrowIfNull(newPrice);

            if(!Active) return false;

            if(newPrice.Currency != TargetPrice.Currency) throw new InvalidOperationException("Currency must be the same."); ;

            if (newPrice.Price < TargetPrice.Price)
            {
                Active = false;
                AlertDate = DateTime.Now;

                _domainEvents.Add(new PriceAlertEvent(
                    Id,ProductId,UserId,TargetPrice,newPrice));
                return true;
            }

            return false;
        }

        public void ClearDomainEvent() => _domainEvents.Clear();

    }
}
