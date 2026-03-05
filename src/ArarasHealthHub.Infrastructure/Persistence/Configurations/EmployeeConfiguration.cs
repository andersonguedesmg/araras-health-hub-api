using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : BaseEntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.ToTable("Employees", t =>
                t.HasComment("Representa um funcionário"));

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Nome do funcionário");

            builder.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(14)
                .HasComment("CPF");

            builder.Property(e => e.Function)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Função");

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Telefone");

            builder.HasIndex(e => e.Cpf)
                .IsUnique();
        }
    }
}
