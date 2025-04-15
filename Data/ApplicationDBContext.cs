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
    public class ApplicationDBContext : IdentityDbContext<AppUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Facility> Facility { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Receiving> Receiving { get; set; }
        public DbSet<ReceivingItem> ReceivingItem { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            int roleMasterId = 1;
            int roleAdminId = 2;
            int roleUserId = 3;

            PasswordHasher<AppUser> hasher = new();

            List<IdentityRole<int>> roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int>
                {
                    Id = roleMasterId,
                    Name = "Master",
                    NormalizedName = "MASTER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },

                new IdentityRole<int>
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },

                new IdentityRole<int>
                {
                    Id = roleUserId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
            };
            builder.Entity<IdentityRole<int>>().HasData(roles);

            builder.Entity<Facility>().HasData(
                new Facility
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
                    UpdatedOn = DateTime.MinValue,
                    IsActive = true,
                }
            );

            AppUser userMaster = new()
            {
                Id = 1,
                UserName = "SMS_Master",
                NormalizedUserName = "SMS_MASTER",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.MinValue,
                IsActive = true,
                FacilityId = 1,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            userMaster.PasswordHash = hasher.HashPassword(userMaster, "A2H@Master");
            builder.Entity<AppUser>().HasData(userMaster);

            IdentityUserRole<int> userMasterRole = new()
            {
                RoleId = 1,
                UserId = 1,
            };
            builder.Entity<IdentityUserRole<int>>().HasData(userMasterRole);
        }
    }
}
