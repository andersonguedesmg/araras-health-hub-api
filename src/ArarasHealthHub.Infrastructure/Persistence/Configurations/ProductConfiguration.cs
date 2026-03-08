using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products", t =>
                t.HasComment("Representa um produto"));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasComment("Nome do produto");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasComment("Descrição do produto");

            builder.HasOne(p => p.MainCategory)
                .WithMany(m => m.Products)
                .HasForeignKey(p => p.MainCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SubCategory)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PackagingType)
                .WithMany(f => f.Products)
                .HasForeignKey(p => p.PackagingTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
