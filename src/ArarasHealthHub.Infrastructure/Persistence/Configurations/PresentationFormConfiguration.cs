using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class PresentationFormConfiguration : BaseEntityConfiguration<PresentationForm>
    {
        public override void Configure(EntityTypeBuilder<PresentationForm> builder)
        {
            base.Configure(builder);

            builder.ToTable("PresentationForms", t =>
                t.HasComment("Representa uma forma de apresentação do produto (ex: Frasco, Ampola, Comprimido)"));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome da forma de apresentação");

            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
