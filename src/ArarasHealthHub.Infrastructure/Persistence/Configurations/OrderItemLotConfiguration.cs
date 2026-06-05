using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderItemLotConfiguration : BaseEntityConfiguration<OrderItemLot>
    {
        public override void Configure(EntityTypeBuilder<OrderItemLot> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItemLots", t =>
            {
                t.HasComment("Lotes efetivamente separados para atendimento do item do pedido");
            });

            builder.Property(x => x.Quantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.UnitValue)
                .HasPrecision(18, 2);

            builder.Property(x => x.TotalValue)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.OrderItem)
                .WithMany(x => x.OrderItemLots)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.StockLot)
                .WithMany()
                .HasForeignKey(x => x.StockLotId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
