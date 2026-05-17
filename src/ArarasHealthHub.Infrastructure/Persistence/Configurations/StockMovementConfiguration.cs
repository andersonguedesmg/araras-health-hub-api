using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class StockMovementConfiguration : BaseEntityConfiguration<StockMovement>
    {
        public override void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            base.Configure(builder);

            builder.ToTable("StockMovements", t =>
            {
                t.HasComment(
                    "Histórico de movimentações de estoque"
                    );

                t.HasCheckConstraint(
                    "CK_StockMovement_Quantity",
                    "[Quantity] > 0"
                    );

                t.HasCheckConstraint(
                    "CK_StockMovement_MovementCost",
                    "[MovementCost] >= 0"
                    );
            });

            builder.Property(x => x.Quantity)
                .HasPrecision(18, 3)
                .IsRequired();

            builder.Property(x => x.MovementCost)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.SourceDocumentType)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Direction)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.Reason)
                .HasConversion<int>()
                .IsRequired();

            builder.HasIndex(x => x.StockLotId);

            builder.HasIndex(x => x.MovementDate);

            builder.HasIndex(x => x.Direction);

            builder.HasIndex(x => x.Reason);

            builder.HasIndex(x => new
            {
                x.SourceDocumentId,
                x.SourceDocumentType
            });

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey(x => x.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StockLot)
                .WithMany()
                .HasForeignKey(x => x.StockLotId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
