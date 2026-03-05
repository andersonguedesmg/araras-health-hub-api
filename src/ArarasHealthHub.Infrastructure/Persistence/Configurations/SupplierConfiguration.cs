using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : BaseEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            {
                base.Configure(builder);

                builder.ToTable("Suppliers", t =>
                    t.HasComment("Representa um fornecedor"));

                builder.HasKey(s => s.Id);

                builder.Property(s => s.LegalName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("Razão Social");

                builder.Property(s => s.TradeName)
                    .HasMaxLength(200)
                    .HasComment("Nome Fantasia");

                builder.Property(s => s.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasComment("CNPJ");

                builder.OwnsOne(s => s.Address, address =>
                {
                    address.ToTable("Suppliers");
                    address.WithOwner();

                    address.Property(a => a.Cep)
                        .HasColumnName("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasComment("CEP");

                    address.Property(a => a.Street)
                        .HasColumnName("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasComment("Logradouro");

                    address.Property(a => a.Number)
                        .HasColumnName("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasComment("Número");

                    address.Property(a => a.Complement)
                        .HasColumnName("Complement")
                        .HasMaxLength(100)
                        .HasComment("Complemento");

                    address.Property(a => a.Neighborhood)
                        .HasColumnName("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasComment("Bairro");

                    address.Property(a => a.City)
                        .HasColumnName("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasComment("Cidade");

                    address.Property(a => a.State)
                        .HasColumnName("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasComment("UF");
                });

                builder.OwnsOne(s => s.Contact, contact =>
                {
                    contact.ToTable("Suppliers");
                    contact.WithOwner();

                    contact.Property(c => c.Email)
                        .HasColumnName("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasComment("E-mail");

                    contact.Property(c => c.Phone)
                        .HasColumnName("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasComment("Telefone");
                });
            }
        }
    }
}
