using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.ProductURL)
                .HasMaxLength(1000)
                .IsRequired();

            // The Value Object "Price" map as a integrated property (ComplexProperty)
            builder.ComplexProperty(p => p.CurrentPrice, precioBuilder =>
            {
                precioBuilder.Property(p => p.PriceValue)
                    .HasColumnName("CurrentPrice_Value")
                    .HasPrecision(18, 2)
                    .IsRequired();

                precioBuilder.Property(p => p.Currency)
                    .HasColumnName("CurrentPrice_Currency")
                    .HasMaxLength(3)
                    .IsRequired();
            });
        }
    }
}
