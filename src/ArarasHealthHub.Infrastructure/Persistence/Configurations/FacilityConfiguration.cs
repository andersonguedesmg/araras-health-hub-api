using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class FacilityConfiguration : BaseEntityConfiguration<Facility>
    {
        public override void Configure(EntityTypeBuilder<Facility> builder)
        {
            {
                base.Configure(builder);

                builder.ToTable("Facilities", t =>
                    t.HasComment("Representa uma unidade"));

                builder.HasKey(f => f.Id);

                builder.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Nome da unidade");

                builder.Property(f => f.Cnes)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasComment("Código CNES");

                builder.OwnsOne(f => f.Address, address =>
                {
                    address.ToTable("Facilities");
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

                builder.OwnsOne(f => f.Contact, contact =>
                {
                    contact.ToTable("Facilities");
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
