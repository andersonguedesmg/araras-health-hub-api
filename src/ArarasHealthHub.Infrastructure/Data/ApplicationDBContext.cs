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

        public new DbSet<IdentityUserRole<int>> UserRoles { get; set; } = default!;
        public new DbSet<IdentityRole<int>> Roles { get; set; } = default!;
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<PresentationForm> PresentationForms { get; set; }
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
        public DbSet<OrderItemLot> OrderItemLots { get; set; }
        public DbSet<DispenseReturn> DispenseReturns { get; set; }
        public DbSet<DispenseReturnItem> DispenseReturnItem { get; set; }

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

            builder.Entity<MainCategory>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();

                entity.HasMany(m => m.SubCategories)
                      .WithOne(s => s.MainCategory)
                      .HasForeignKey(s => s.MainCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SubCategory>(entity =>
            {
                entity.HasIndex(e => new { e.MainCategoryId, e.Name }).IsUnique();
            });

            builder.Entity<PresentationForm>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.MainCategory)
                      .WithMany(m => m.Products)
                      .HasForeignKey(p => p.MainCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.SubCategory)
                      .WithMany(s => s.Products)
                      .HasForeignKey(p => p.SubCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.PresentationForm)
                      .WithMany(f => f.Products)
                      .HasForeignKey(p => p.PresentationFormId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


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
                    ConcurrencyStamp = "f2c9a0c0-7b1f-4e53-9b8a-3a0f1f4d8b11",
                },
                new IdentityRole<int>
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "9a6a4b78-0d51-4b4b-9d65-2a7a8bfc9e32",
                },
                new IdentityRole<int>
                {
                    Id = roleUserId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "c7f9c1aa-1c9a-4c4e-b8fa-5c8a2c1f3a99",
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
                        Complement = "",
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
                        Email = "saude@araras.sp.gov.br",
                        Phone = "(19) 3543-1522"
                    }
                );
            });

            builder.Entity<Facility>().HasData(
                new
                {
                    Id = 1,
                    Name = "Secretária Municipal da Saúde - Dr. João Geraldo Noronha",
                    Cnes = "6345921",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 08, 35, 14), DateTimeKind.Utc),
                    IsActive = true
                }
            );

            // --- Seed do Usuário Principal ---
            ApplicationUser userMaster = new()
            {
                Id = 1,
                UserName = "saude_master",
                NormalizedUserName = "SAUDE_MASTER",
                CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 09, 14, 35), DateTimeKind.Utc),
                UpdatedOn = null,
                IsActive = true,
                FacilityId = facilityPrincipalId,
                Scope = UserScopeEnum.Management,
                SecurityStamp = "D8A2F6E1-7B32-4C6F-BB5A-91C3E62E8A11",
                ConcurrencyStamp = "3F1C7B9A-1C8E-4E3B-A4F5-8C6B7F2E1D99",
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
                new OrderStatus { Id = 1, Description = "Pendente de Aprovação" },
                new OrderStatus { Id = 2, Description = "Pronto para Separação" },
                new OrderStatus { Id = 3, Description = "Em Separação" },
                new OrderStatus { Id = 4, Description = "Pronto para Envio/Finalização" },
                new OrderStatus { Id = 5, Description = "Finalizado" },
                new OrderStatus { Id = 6, Description = "Cancelado" },
            };
            builder.Entity<OrderStatus>().HasData(orderStatus);

            // --- Seed de Categoria Principal ---
            builder.Entity<MainCategory>().HasData(
                new
                {
                    Id = 1,
                    Name = "Pendente",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 11, 22, 33), DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 2,
                    Name = "Material Hospitalar",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 11, 25, 14), DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 3,
                    Name = "Material de Limpeza",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 11, 27, 21), DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 4,
                    Name = "Material de Apoio e Administrativo",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 11, 30, 38), DateTimeKind.Utc),
                    IsActive = true
                }
            );



            // --- Configurações de Precisão ---
            // --- Regras de Padronização:
            // --- - Quantidades: decimal(18, 3).
            // --- - Valores Monetários: decimal(18, 2).
            // --- - Alta Precisão: decimal(18, 4).
            builder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.CurrentQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.ReservedQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.AvailableQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.MinQuantity)
                    .HasPrecision(18, 3);
            });

            builder.Entity<StockMovement>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.MovementCost)
                    .HasPrecision(18, 2);

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
                    .WithOne(s => s.StockCost)
                    .HasForeignKey<StockCost>(sc => sc.StockId)
                    .IsRequired();
            });

            builder.Entity<ReceivedItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.UnitValue)
                    .HasPrecision(18, 2);

                entity.Property(e => e.TotalValue)
                    .HasPrecision(18, 2);
            });

            builder.Entity<StockAdjustmentItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.UnitValue)
                    .HasPrecision(18, 2);

                entity.Property(e => e.TotalValue)
                    .HasPrecision(18, 2);
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.RequestedQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.ApprovedQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.ReservedQuantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.ActualQuantity)
                    .HasPrecision(18, 3);
            });

            builder.Entity<DispenseReturnItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.UnitValue)
                    .HasPrecision(18, 2);

                entity.Property(e => e.TotalValue)
                    .HasPrecision(18, 2);
            });

            builder.Entity<DispenseReturn>(entity =>
            {
                entity.Property(e => e.TotalReturnedValue)
                    .HasPrecision(18, 2);
            });

            builder.Entity<DispenseReturn>(entity =>
            {
                entity.Property(e => e.TotalReturnedValue)
                    .HasPrecision(18, 2);

                entity.HasOne(dr => dr.OriginalOrder)
                    .WithMany()
                    .HasForeignKey(dr => dr.OriginalOrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dr => dr.ReturnedByEmployee)
                    .WithMany()
                    .HasForeignKey(dr => dr.ReturnedByEmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dr => dr.ReturnedByAccount)
                    .WithMany()
                    .HasForeignKey(dr => dr.ReturnedByAccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderItemLot>(entity =>
            {
                entity.Property(e => e.Quantity)
                    .HasPrecision(18, 3);

                entity.Property(e => e.UnitValue)
                    .HasPrecision(18, 2);

                entity.Property(e => e.TotalValue)
                    .HasPrecision(18, 2);
            });

            builder.Entity<Receiving>(entity =>
            {
                entity.Property(e => e.TotalValue)
                    .HasPrecision(18, 2);
            });
        }
    }
}
