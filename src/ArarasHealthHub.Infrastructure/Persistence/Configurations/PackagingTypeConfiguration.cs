using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class PackagingTypeConfiguration : BaseEntityConfiguration<PackagingType>
    {
        public override void Configure(EntityTypeBuilder<PackagingType> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackagingTypes", t =>
                t.HasComment("Representa um tipo de embalagem do produto (ex: Frasco, Ampola, Comprimido)"));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do tipo de embalagem");

            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
