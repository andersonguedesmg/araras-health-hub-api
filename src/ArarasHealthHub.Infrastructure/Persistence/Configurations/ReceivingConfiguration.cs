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
                t.HasComment("Representa o registro de entrada no estoque"));

            builder.Property(x => x.InvoiceNumber)
                .HasMaxLength(50);

            builder.Property(x => x.SupplyAuthorization)
                .HasMaxLength(50);

            builder.Property(x => x.TotalValue)
                .HasPrecision(18, 3);

            builder.HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId);

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey(x => x.ResponsibleId);

            builder.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountId);

            builder.HasMany(typeof(ReceivedItem), "_items")
                .WithOne(nameof(ReceivedItem.Receiving))
                .HasForeignKey(nameof(ReceivedItem.ReceivingId));
        }
    }
}
