using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ArarasHealthHub.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; }

        DbSet<ApplicationUser> ApplicationUsers { get; }
        DbSet<Facility> Facilities { get; }
        DbSet<Supplier> Suppliers { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Product> Products { get; }
        DbSet<MainCategory> MainCategories { get; }
        DbSet<SubCategory> SubCategories { get; }
        DbSet<PackagingType> PackagingTypes { get; }
        DbSet<Receiving> Receivings { get; }
        DbSet<ReceivedItem> ReceivedItems { get; }
        DbSet<Stock> Stocks { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<OrderStatus> OrderStatuses { get; }
        DbSet<StockMovement> StockMovements { get; }
        DbSet<StockAdjustment> StockAdjustments { get; }
        DbSet<StockAdjustmentItem> StockAdjustmentItems { get; }
        DbSet<StockLot> StockLots { get; }
        DbSet<StockCost> StockCosts { get; }
        DbSet<OrderItemLot> OrderItemLots { get; }
        DbSet<OrderReturn> OrderReturns { get; }
        DbSet<OrderReturnItem> OrderReturnItems { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
