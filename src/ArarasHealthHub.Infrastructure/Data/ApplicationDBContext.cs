using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Infrastructure.Persistence.Seeds;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ArarasHealthHub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityUserContext<ApplicationUser, int>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public new DatabaseFacade Database => base.Database;

        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<Facility> Facilities => Set<Facility>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<MainCategory> MainCategories => Set<MainCategory>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<PackagingType> PackagingTypes => Set<PackagingType>();
        public DbSet<Receiving> Receivings => Set<Receiving>();
        public DbSet<ReceivedItem> ReceivedItems => Set<ReceivedItem>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<StockMovement> StockMovements => Set<StockMovement>();
        public DbSet<StockAdjustment> StockAdjustments => Set<StockAdjustment>();
        public DbSet<StockAdjustmentItem> StockAdjustmentItems => Set<StockAdjustmentItem>();
        public DbSet<StockLot> StockLots => Set<StockLot>();
        public DbSet<StockCost> StockCosts => Set<StockCost>();
        public DbSet<OrderItemLot> OrderItemLots => Set<OrderItemLot>();
        public DbSet<OrderReturn> OrderReturns => Set<OrderReturn>();
        public DbSet<OrderReturnItem> OrderReturnItems => Set<OrderReturnItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            FacilitySeed.Seed(builder);
            FacilityAddressSeed.Seed(builder);
            FacilityContactSeed.Seed(builder);
            ApplicationUserSeed.Seed(builder);
            OrderStatusSeed.Seed(builder);
        }
    }
}
