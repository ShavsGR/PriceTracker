using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain
{
    public record Precio
    {
        public decimal Price { get; set; }
        public string Currency {  get; set; }

        public Precio(decimal price, string currency)
        {
            if(price < 0)
            {
                throw new ArgumentException("Cant have negative price");
            }

            
            if (string.IsNullOrWhiteSpace(currency)) 
            {
                throw new ArgumentException("It needs to have a currency");
            }

            Price = decimal.Round(price,2);
            Currency = currency;
        }

        public static Precio EnEuros(decimal price) => new Precio(price, "EUR");
    }
}
