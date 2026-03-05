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
                t.HasComment("Representa o estoque detalhado de um produto por lote, valor e validade"));

            builder.HasIndex(x => new { x.StockId, x.Batch }).IsUnique();

            builder.Property(x => x.Batch)
                .HasMaxLength(50)
                .HasComment("Número do lote");

            builder.Property(x => x.Brand)
                .HasMaxLength(100);

            builder.Property(x => x.UnitValue)
                .HasPrecision(18, 2);

            builder.Property(x => x.AvailableQuantity)
                .HasPrecision(18, 3);

            builder.HasOne(x => x.Stock)
                .WithMany(s => s.Lots)
                .HasForeignKey(x => x.StockId);

            builder.HasOne(x => x.ReceivedItem)
                .WithMany()
                .HasForeignKey(x => x.ReceivedItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
