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
            {
                t.HasComment(
                    "Representa o estoque consolidado do produto"
                );

                t.HasCheckConstraint(
                    "CK_Stock_CurrentQuantity",
                    "[CurrentQuantity] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_Stock_ReservedQuantity",
                    "[ReservedQuantity] >= 0"
                );
            });

            builder.HasIndex(x => x.ProductId)
                .IsUnique();

            builder.Property(x => x.CurrentQuantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(x => x.ReservedQuantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Ignore(x => x.AvailableQuantity);

            builder.Property(x => x.MinQuantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithOne(x => x.Stock)
                .HasForeignKey<Stock>(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StockCost)
                .WithOne(x => x.Stock)
                .HasForeignKey<StockCost>(x => x.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Lots)
                .WithOne(x => x.Stock)
                .HasForeignKey(x => x.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Lots)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Stock.Lots))!
                .SetField("_lots");
        }
    }
}
