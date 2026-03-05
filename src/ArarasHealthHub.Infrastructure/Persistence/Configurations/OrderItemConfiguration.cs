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

            builder.ToTable("OrderItems");

            builder.Property(x => x.RequestedQuantity).HasPrecision(18, 3);
            builder.Property(x => x.ApprovedQuantity).HasPrecision(18, 3);
            builder.Property(x => x.ReservedQuantity).HasPrecision(18, 3);
            builder.Property(x => x.ActualQuantity).HasPrecision(18, 3);

            builder.HasOne(x => x.Order)
                .WithMany("_items")
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata
                .FindNavigation(nameof(OrderItem.OrderItemLots))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
