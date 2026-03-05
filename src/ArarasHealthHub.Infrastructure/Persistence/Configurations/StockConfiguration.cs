using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class StockConfiguration : BaseEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);

            builder.ToTable("Stocks", t =>
                t.HasComment("Representa o estoque atual de um produto (visão consolidada)"));

            builder.HasIndex(x => x.ProductId).IsUnique();

            builder.Property(x => x.CurrentQuantity)
                .HasPrecision(18, 3)
                .HasComment("Quantidade total disponível.");

            builder.Property(x => x.ReservedQuantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.AvailableQuantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.MinQuantity)
                .HasPrecision(18, 3);

            builder.HasOne(x => x.Product)
                .WithOne(p => p.Stock)
                .HasForeignKey<Stock>(x => x.ProductId);

            builder.HasOne(x => x.StockCost)
                .WithOne(c => c.Stock)
                .HasForeignKey<StockCost>(c => c.StockId);
        }
    }
}
