using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class SubCategoryConfiguration : BaseEntityConfiguration<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("SubCategories", t =>
                t.HasComment("Representa uma subcategoria vinculada a categoria principal de produtos (ex: Antibiótico, Analgésico, Antialérgico)"));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome da subcategoria");

            builder.HasOne(s => s.MainCategory)
                .WithMany(m => m.SubCategories)
                .HasForeignKey(s => s.MainCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.MainCategoryId, s.Name })
                .IsUnique();
        }
    }
}
