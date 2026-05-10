using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class ReceivingConfiguration : BaseEntityConfiguration<Receiving>
    {
        public override void Configure(EntityTypeBuilder<Receiving> builder)
        {
            base.Configure(builder);

            builder.ToTable("Receivings", t =>
            {
                t.HasComment(
                    "Representa o registro de entrada de produtos no estoque"
                );

                t.HasCheckConstraint(
                    "CK_Receiving_InvoiceNumber",
                    "[InvoiceNumber] <> ''"
                );
            });

            builder.Property(x => x.InvoiceNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.SupplyAuthorization)
                .HasMaxLength(50);

            builder.Property(x => x.Observation)
                .HasMaxLength(500);

            builder.Ignore(x => x.TotalValue);

            builder.HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey(x => x.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Receiving)
                .HasForeignKey(x => x.ReceivingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Receiving.Items))!
                .SetField("_items");
        }
    }
}
