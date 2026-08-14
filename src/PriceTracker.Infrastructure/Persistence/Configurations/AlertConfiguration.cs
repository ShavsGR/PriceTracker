using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Infrastructure.Persistence.Configurations
{
    public class AlertConfiguration : IEntityTypeConfiguration<PriceAlert>
    {
        public void Configure(EntityTypeBuilder<PriceAlert> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ProductId).IsRequired();
            builder.Property(a => a.UserId).IsRequired();

            builder.ComplexProperty(a => a.TargetPrice, precioBuilder =>
            {
                precioBuilder.Property(p => p.PriceValue)
                    .HasColumnName("TargetPrice_Value")
                    .HasPrecision(18, 2)
                    .IsRequired();

                precioBuilder.Property(p => p.Currency)
                    .HasColumnName("TargetPrice_Currency")
                    .HasMaxLength(3)
                    .IsRequired();
            });

            // Ignore domain events in the table persistence
            builder.Ignore(a => a.DomainEvents);
        }
    }
}
