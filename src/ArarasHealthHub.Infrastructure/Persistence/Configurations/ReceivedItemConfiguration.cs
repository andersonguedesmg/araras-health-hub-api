using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class ReceivedItemConfiguration : BaseEntityConfiguration<ReceivedItem>
    {
        public override void Configure(EntityTypeBuilder<ReceivedItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("ReceivedItems", t =>
            {
                t.HasComment(
                    "Representa um item específico de um recebimento");

                t.HasCheckConstraint(
                    "CK_ReceivedItems_Quantity",
                    "\"Quantity\" > 0");

                t.HasCheckConstraint(
                    "CK_ReceivedItems_UnitValue",
                    "\"UnitValue\" >= 0");
            });

            builder.Property(x => x.Quantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(x => x.UnitValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Ignore(x => x.TotalValue);

            builder.Property(x => x.Batch)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Brand)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.ExpiryDate)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Receiving)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.ReceivingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
