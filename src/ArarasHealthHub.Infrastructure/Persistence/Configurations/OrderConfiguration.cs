using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Orders", t =>
            {
                t.HasComment("Representa um pedido de dispensação");
            });

            builder.Property(x => x.Observation)
                .HasMaxLength(500);

            builder.Property(x => x.CancellationReason)
                .HasMaxLength(500);

            builder.HasOne(x => x.OrderFacility)
                .WithMany()
                .HasForeignKey(x => x.OrderFacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OrderStatus)
                .WithMany()
                .HasForeignKey(x => x.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedByEmployee)
                .WithMany()
                .HasForeignKey(x => x.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedByAccount)
                .WithMany()
                .HasForeignKey(x => x.CreatedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ApprovedByEmployee)
                .WithMany()
                .HasForeignKey(x => x.ApprovedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ApprovedByAccount)
                .WithMany()
                .HasForeignKey(x => x.ApprovedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SeparatedByEmployee)
                .WithMany()
                .HasForeignKey(x => x.SeparatedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SeparatedByAccount)
                .WithMany()
                .HasForeignKey(x => x.SeparatedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FinalizedByEmployee)
                .WithMany()
                .HasForeignKey(x => x.FinalizedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FinalizedByAccount)
                .WithMany()
                .HasForeignKey(x => x.FinalizedByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CanceledByEmployee)
                .WithMany()
                .HasForeignKey(x => x.CanceledByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CanceledByAccount)
                .WithMany()
                .HasForeignKey(x => x.CanceledByAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.OrderItems)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Order.OrderItems))!
                .SetField("_items");
        }
    }
}
