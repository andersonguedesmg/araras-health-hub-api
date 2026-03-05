using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class MainCategoryConfiguration : BaseEntityConfiguration<MainCategory>
    {
        public override void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("MainCategories", t =>
                t.HasComment("Representa uma categoria principal de produtos (ex: Medicamento, Material Hospitalar, Material de Limpeza)"));

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome da categoria principal");

            builder.HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}
