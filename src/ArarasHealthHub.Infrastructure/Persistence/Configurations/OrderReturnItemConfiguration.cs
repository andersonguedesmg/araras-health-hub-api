using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderReturnItemConfiguration : BaseEntityConfiguration<OrderReturnItem>
    {
        public override void Configure(
            EntityTypeBuilder<OrderReturnItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderReturnItems", t =>
            {
                t.HasComment("Itens devolvidos ao estoque");

                t.HasCheckConstraint(
                    "CK_OrderReturnItem_Quantity",
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

            builder.HasOne(x => x.OrderReturn)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderReturnId)
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
