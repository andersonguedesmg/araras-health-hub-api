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
                t.HasComment("Representa uma devolução de itens dispensados de um pedido ao estoque"));

            builder.Property(x => x.Reason)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.TotalReturnedValue)
                .HasPrecision(18, 2);

            builder.HasOne(x => x.OriginalOrder)
                .WithMany()
                .HasForeignKey(x => x.OriginalOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Metadata
                .FindNavigation(nameof(DispenseReturn.ReturnItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
