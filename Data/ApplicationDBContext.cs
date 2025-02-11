using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Destination> Destination { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Guid roleMasterId = Guid.NewGuid();
            Guid roleAdminId = Guid.NewGuid();
            Guid roleUserId = Guid.NewGuid();

            Guid userMasterId = Guid.NewGuid();
            PasswordHasher<AppUser> hasher = new();

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = roleMasterId.ToString(),
                    Name = "Master",
                    NormalizedName = "MASTER",
                },

                new IdentityRole
                {
                    Id = roleAdminId.ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },

                new IdentityRole
                {
                    Id = roleUserId.ToString(),
                    Name = "User",
                    NormalizedName = "USER",
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<Destination>().HasData(
                new Destination
                {
                    Id = 1,
                    Name = "Secretaria Municipal da Saúde",
                    Address = "Rua Campos Sales",
                    Number = "33",
                    Neighborhood = "Jardim Belvedere",
                    City = "Araras",
                    State = "SP",
                    Cep = "13.601-111",
                    Email = "sms@araras.sp.gov.br",
                    Phone = "(19) 3543-1522",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    IsActive = true,
                }
            );

            AppUser userMaster = new()
            {
                Id = userMasterId.ToString(),
                UserName = "SMS_Master",
                NormalizedUserName = "SMS_MASTER",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = true,
                DestinationId = 1,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            userMaster.PasswordHash = hasher.HashPassword(userMaster, "A2H@Master");
            builder.Entity<AppUser>().HasData(userMaster);

            IdentityUserRole<string> userMasterRole = new()
            {
                RoleId = roleMasterId.ToString(),
                UserId = userMasterId.ToString(),
            };
            builder.Entity<IdentityUserRole<string>>().HasData(userMasterRole);
        }
    }
}
