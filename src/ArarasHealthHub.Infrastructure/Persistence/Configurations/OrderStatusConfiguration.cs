using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class OrderStatusConfiguration : BaseEntityConfiguration<OrderStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderStatuses", t =>
                t.HasComment("Tabela de lookup para os status possíveis de um pedido"));

            builder.Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
