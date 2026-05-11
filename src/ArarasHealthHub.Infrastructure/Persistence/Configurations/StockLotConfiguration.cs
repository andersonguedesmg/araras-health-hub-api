using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class StockLotConfiguration : BaseEntityConfiguration<StockLot>
    {
        public override void Configure(EntityTypeBuilder<StockLot> builder)
        {
            base.Configure(builder);

            builder.ToTable("StockLots", t =>
            {
                t.HasComment(
                    "Representa o estoque por lote"
                );

                t.HasCheckConstraint(
                    "CK_StockLot_AvailableQuantity",
                    "[AvailableQuantity] >= 0"
                );

                t.HasCheckConstraint(
                    "CK_StockLot_UnitValue",
                    "[UnitValue] >= 0"
                );
            });

            builder.HasIndex(x =>
                new
                {
                    x.StockId,
                    x.Batch,
                    x.ExpiryDate
                });

            builder.Property(x => x.Batch)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Brand)
                .HasMaxLength(100);

            builder.Property(x => x.UnitValue)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.AvailableQuantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(x => x.ExpiryDate)
                .IsRequired();

            builder.HasOne(x => x.Stock)
                .WithMany(x => x.Lots)
                .HasForeignKey(x => x.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ReceivedItem)
                .WithMany()
                .HasForeignKey(x => x.ReceivedItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
