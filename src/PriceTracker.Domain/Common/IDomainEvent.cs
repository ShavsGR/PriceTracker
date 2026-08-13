using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Domain.Common
{
    public interface IDomainEvent
    {
        public DateTime EventDate { get; set; }
    }
}
