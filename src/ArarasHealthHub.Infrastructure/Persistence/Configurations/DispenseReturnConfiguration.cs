using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class DispenseReturnConfiguration : BaseEntityConfiguration<DispenseReturn>
    {
        public override void Configure(EntityTypeBuilder<DispenseReturn> builder)
        {
            base.Configure(builder);

            builder.ToTable("DispenseReturns", t =>
            {
                t.HasComment(
                    "Representa devoluções de itens dispensados"
                );
            });

            builder.Property(x => x.Reason)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ReturnDate)
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
                .WithOne(x => x.DispenseReturn)
                .HasForeignKey(x => x.DispenseReturnId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(DispenseReturn.Items))!
                .SetField("_items");

            builder.HasIndex(x => x.OriginalOrderId);

            builder.HasIndex(x => x.ReturnDate);
        }
    }
}
