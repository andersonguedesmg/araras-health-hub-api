using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
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
        public DbSet<ReceivedItem> ReceivedItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockAdjustmentItem> StockAdjustmentItem { get; set; }
        public DbSet<StockLot> StockLots { get; set; }
        public DbSet<StockCost> StockCosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Facility)
                .WithMany(f => f.Accounts)
                .HasForeignKey(u => u.FacilityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Facility>().OwnsOne(f => f.Address);
            builder.Entity<Facility>().OwnsOne(f => f.Contact);

            builder.Entity<Supplier>().OwnsOne(f => f.Address);
            builder.Entity<Supplier>().OwnsOne(f => f.Contact);

            builder.Entity<Receiving>().Property(r => r.Id).UseIdentityColumn();

            builder.Entity<Employee>()
                .HasIndex(e => e.Cpf)
                .IsUnique();

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
            builder.Entity<Facility>(entity =>
            {
                entity.OwnsOne(f => f.Address).HasData(
                    new
                    {
                        FacilityId = 1,
                        Cep = "13601-111",
                        Street = "Rua Campos Sales",
                        Number = "33",
                        Neighborhood = "Jardim Belvedere",
                        City = "Araras",
                        State = "SP"
                    }
                );

                entity.OwnsOne(f => f.Contact).HasData(
                    new
                    {
                        FacilityId = 1,
                        Email = "sms@araras.sp.gov.br",
                        Phone = "(19) 3543-1522"
                    }
                );
            });

            builder.Entity<Facility>().HasData(
                new
                {
                    Id = 1,
                    Name = "Secretaria Municipal da Saúde",
                    CreatedOn = new DateTime(2024, 01, 01),
                    IsActive = true
                }
            );

            // --- Seed do Usuário Principal ---
            ApplicationUser userMaster = new()
            {
                Id = 1,
                UserName = "sms_master",
                NormalizedUserName = "SMS_MASTER",

                EmailConfirmed = true,
                LockoutEnabled = true,

                FacilityId = facilityPrincipalId,
                Scope = UserScopeEnum.Management,
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

            // --- Configurações de precisão ---
            builder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.CurrentQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.MinQuantity)
                    .HasPrecision(18, 3);
            });

            builder.Entity<StockMovement>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.HasOne(sm => sm.StockLot)
                .WithMany()
                .HasForeignKey(sm => sm.StockLotId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StockLot>(entity =>
            {
                entity.Property(e => e.AvailableQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.UnitValue)
                    .HasPrecision(18, 2);

                entity.HasOne(sl => sl.Stock)
                    .WithMany(s => s.Lots)
                    .HasForeignKey(sl => sl.StockId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sl => sl.ReceivedItem)
                    .WithMany()
                    .HasForeignKey(sl => sl.ReceivedItemId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StockCost>(entity =>
            {
                entity.Property(e => e.AverageUnitCost)
                    .HasPrecision(18, 4);

                entity.Property(e => e.CurrentTotalCost)
                    .HasPrecision(18, 2);

                entity.HasOne(sc => sc.Stock)
                      .WithOne()
                      .HasForeignKey<StockCost>(sc => sc.StockId)
                      .IsRequired();
            });

            builder.Entity<ReceivedItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);
            });

            builder.Entity<StockAdjustmentItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 6);
            });
        }
    }
}
