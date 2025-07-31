using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ArarasHealthHub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public new DatabaseFacade Database => base.Database;

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receiving> Receivings { get; set; }
        public DbSet<ReceivingItem> ReceivingItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // --- Seed das Funções ---
            int roleMasterId = 1;
            int roleAdminId = 2;
            int roleUserId = 3;

            List<IdentityRole<int>> roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int>
                {
                    Id = roleMasterId,
                    Name = "Master",
                    NormalizedName = "MASTER",
                    ConcurrencyStamp = Guid.Empty.ToString(),
                },
                new IdentityRole<int>
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.Empty.ToString(),
                },
                new IdentityRole<int>
                {
                    Id = roleUserId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.Empty.ToString(),
                },
            };
            builder.Entity<IdentityRole<int>>().HasData(roles);

            // --- Seed da Unidade Principal ---
            int facilityPrincipalId = 1;
            builder.Entity<Facility>().HasData(
                new Facility(
                    id: facilityPrincipalId,
                    name: "Secretaria Municipal da Saúde",
                    address: "Rua Campos Sales",
                    number: "33",
                    neighborhood: "Jardim Belvedere",
                    city: "Araras",
                    state: "SP",
                    cep: "13.601-111",
                    email: "sms@araras.sp.gov.br",
                    phone: "(19) 3543-1522",
                    createdOn: DateTime.SpecifyKind(new DateTime(2023, 1, 1), DateTimeKind.Utc),
                    updatedOn: null,
                    isActive: true
                )
            );

            // --- Seed do Usuário Principal ---
            ApplicationUser userMaster = new()
            {
                Id = 1,
                UserName = "sms_master",
                NormalizedUserName = "SMS_MASTER",
                CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc),
                UpdatedOn = null,
                IsActive = true,
                FacilityId = facilityPrincipalId,
                SecurityStamp = Guid.Empty.ToString(),
                ConcurrencyStamp = Guid.Empty.ToString(),
                PasswordHash = "AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==",
            };
            builder.Entity<ApplicationUser>().HasData(userMaster);

            // --- Associar Usuário Principal à Função Master ---
            IdentityUserRole<int> userMasterRole = new()
            {
                RoleId = roleMasterId,
                UserId = userMaster.Id,
            };
            builder.Entity<IdentityUserRole<int>>().HasData(userMasterRole);

            // --- Seed de Status de Pedido ---
            List<OrderStatus> orderStatus = new List<OrderStatus>
            {
                new OrderStatus { Id = 1, Description = "Pendente" },
                new OrderStatus { Id = 2, Description = "Aprovado" },
                new OrderStatus { Id = 3, Description = "Separado" },
                new OrderStatus { Id = 4, Description = "Finalizado" },
            };
            builder.Entity<OrderStatus>().HasData(orderStatus);

            builder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.CurrentQuantity)
                    .HasPrecision(18, 2);
            });
        }
    }
}
