using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain.Entities
{
    public record Price
    {
        public decimal PriceValue { get; set; }
        public string Currency {  get; set; }

        public Price(decimal price, string currency)
        {
            if(price < 0)
            {
                throw new ArgumentException("Cant have negative price");
            }

            
            if (string.IsNullOrWhiteSpace(currency)) 
            {
                throw new ArgumentException("It needs to have a currency");
            }

            PriceValue = decimal.Round(price,2);
            Currency = currency;
        }

        public static Price EnEuros(decimal price) => new Price(price, "EUR");
    }
}
