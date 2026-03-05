using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class StockCostConfiguration : BaseEntityConfiguration<StockCost>
    {
        public override void Configure(EntityTypeBuilder<StockCost> builder)
        {
            base.Configure(builder);

            builder.ToTable("StockCosts");

            builder.ToTable("StockCosts", t =>
                t.HasComment("Armazena o custo médio unitário e o custo total atual do estoque consolidado"));

            builder.HasIndex(x => x.StockId)
                .IsUnique();

            builder.Property(x => x.AverageUnitCost)
                .HasPrecision(18, 4);

            builder.Property(x => x.CurrentTotalCost)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.Stock)
                .WithOne(x => x.StockCost)
                .HasForeignKey<StockCost>(x => x.StockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
