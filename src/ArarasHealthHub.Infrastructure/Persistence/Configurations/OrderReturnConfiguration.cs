using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderReturnConfiguration : BaseEntityConfiguration<OrderReturn>
    {
        public override void Configure(
            EntityTypeBuilder<OrderReturn> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderReturns", t =>
            {
                t.HasComment("Representa devoluções de produtos dispensados em pedidos");
            });

            builder.Property(x => x.Reason)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ReturnedAt)
                .IsRequired();

            builder.Property(x => x.TotalReturnedValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(x => x.OriginalOrder)
                .WithMany()
                .HasForeignKey(x => x.OriginalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReturnedByEmployee)
                .WithMany()
                .HasForeignKey(x => x.ReturnedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReturnedByAccount)
                .WithMany()
                .HasForeignKey(x => x.ReturnedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.OrderReturn)
                .HasForeignKey(x => x.OrderReturnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(OrderReturn.Items))!
                .SetField("_items");

            builder.HasIndex(x => x.OriginalOrderId);

            builder.HasIndex(x => x.ReturnedAt);

            builder.HasIndex(x => new
            {
                x.OriginalOrderId,
                x.ReturnedAt
            });
        }
    }
}
