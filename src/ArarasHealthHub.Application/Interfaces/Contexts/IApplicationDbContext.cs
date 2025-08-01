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

        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Facility> Facilities { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Receiving> Receivings { get; set; }
        DbSet<ReceivingItem> ReceivingItems { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<StockMovement> StockMovements { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
