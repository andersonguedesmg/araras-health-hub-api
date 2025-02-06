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
        public DbSet<DestinationUser> DestinationUser { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName="ADMIN"
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName="USER"
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

        }
    }
}
