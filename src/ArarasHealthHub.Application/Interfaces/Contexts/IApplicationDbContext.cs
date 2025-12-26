using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ArarasHealthHub.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; }

        DbSet<ApplicationUser> Users { get; set; }
        DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        DbSet<IdentityRole<int>> Roles { get; set; }
        DbSet<Facility> Facilities { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<MainCategory> MainCategories { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<PresentationForm> PresentationForms { get; set; }
        DbSet<Receiving> Receivings { get; set; }
        DbSet<ReceivedItem> ReceivedItems { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<StockMovement> StockMovements { get; set; }
        DbSet<StockAdjustment> StockAdjustments { get; set; }
        DbSet<StockAdjustmentItem> StockAdjustmentItem { get; set; }
        DbSet<StockLot> StockLots { get; set; }
        DbSet<StockCost> StockCosts { get; set; }
        DbSet<OrderItemLot> OrderItemLots { get; set; }
        DbSet<DispenseReturn> DispenseReturns { get; set; }
        DbSet<DispenseReturnItem> DispenseReturnItem { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
