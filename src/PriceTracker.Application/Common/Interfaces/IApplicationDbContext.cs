using Microsoft.EntityFrameworkCore;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<PriceAlert> PriceAlerts { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
