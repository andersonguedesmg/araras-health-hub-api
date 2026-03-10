using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArarasHealthHub.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers", t =>
                t.HasComment("Representa uma conta de usuário do sistema"));

            builder.Property(x => x.UserName)
                .HasMaxLength(256);

            builder.Property(x => x.Scope)
                .IsRequired()
                .HasComment("Escopo da conta no sistema.");

            builder.Property(x => x.Role)
                .IsRequired()
                .HasComment("Papel da conta no sistema.");

            builder.Property(x => x.CreatedOn)
                .IsRequired()
                .HasComment("Data de criação da conta.");

            builder.Property(x => x.UpdatedOn)
                .HasComment("Data da última atualização da conta.");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("Indica se a conta está ativa.");

            builder.HasOne(x => x.Facility)
                .WithMany(f => f.Accounts)
                .HasForeignKey(x => x.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
