using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItems", t =>
            {
                t.HasComment("Itens pertencentes ao pedido de dispensação");
            });

            builder.Property(x => x.RequestedQuantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.ApprovedQuantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.ReservedQuantity)
                .HasPrecision(18, 3);

            builder.Property(x => x.ActualQuantity)
                .HasPrecision(18, 3);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderItemLots)
                .WithOne(x => x.OrderItem)
                .HasForeignKey(x => x.OrderItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.OrderItemLots)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(OrderItem.OrderItemLots))!
                .SetField("_lots");
        }
    }
}
