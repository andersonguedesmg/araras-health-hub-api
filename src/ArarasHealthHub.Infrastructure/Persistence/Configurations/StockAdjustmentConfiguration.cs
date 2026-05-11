using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class StockAdjustmentConfiguration : BaseEntityConfiguration<StockAdjustment>
    {
        public override void Configure(EntityTypeBuilder<StockAdjustment> builder)
        {
            base.Configure(builder);

            builder.ToTable("StockAdjustments", t =>
            {
                t.HasComment(
                    "Representa um ajuste manual de estoque"
                );
            });

            builder.Property(x => x.Type)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.Reason)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Observation)
                .HasMaxLength(500);

            builder.Property(x => x.AdjustmentDate)
                .IsRequired();

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey(x => x.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.StockAdjustment)
                .HasForeignKey(x => x.StockAdjustmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(StockAdjustment.Items))!
                .SetField("_items");
        }
    }
}
