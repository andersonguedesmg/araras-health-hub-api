using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class DispenseReturnItemConfiguration : BaseEntityConfiguration<DispenseReturnItem>
    {
        public override void Configure(EntityTypeBuilder<DispenseReturnItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("DispenseReturnItems", t =>
            {
                t.HasComment(
                    "Itens devolvidos ao estoque"
                );

                t.HasCheckConstraint(
                    "CK_DispenseReturnItem_Quantity",
                    "\"Quantity\" > 0"
                );
            });

            builder.Property(x => x.Quantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(x => x.UnitValue)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.TotalValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Batch)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Brand)
                .HasMaxLength(100);

            builder.Property(x => x.ExpiryDate)
                .IsRequired();

            builder.HasOne(x => x.DispenseReturn)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.DispenseReturnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StockLot)
                .WithMany()
                .HasForeignKey(x => x.StockLotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ProductId);

            builder.HasIndex(x => x.StockLotId);
        }
    }
}
