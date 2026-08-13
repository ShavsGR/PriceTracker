using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain
{
    public class Producto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string ProductURL { get; private set; } = string.Empty;
        public Precio CurrentPrice { get; private set; }
        public DateTime PublishDateTime { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public Producto(string name, string url, Precio currentPrice)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Needs a valid name");

            if(string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("Needs a valid URL");

            if (currentPrice == null) throw new ArgumentException("Needs a valid price");

            Id = Guid.NewGuid();
            Name = name;
            CurrentPrice = currentPrice;
            PublishDateTime = DateTime.Now;
        }

        public void UpdatePrice(Precio newPrice)
        {
            if (newPrice == null) throw new ArgumentNullException(nameof(newPrice));
            if (CurrentPrice.Currency != newPrice.Currency) throw new InvalidOperationException("Price need to have same currency");

            CurrentPrice = newPrice;
            LastUpdate = DateTime.Now;

        }

    }
}
