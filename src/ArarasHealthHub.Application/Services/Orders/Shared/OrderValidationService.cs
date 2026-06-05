using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Services.Orders.Shared
{
    public sealed class OrderValidationService : IOrderValidationService
    {
        private readonly IApplicationDbContext _dbContext;

        public OrderValidationService(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> EnsureEmployeeExistsAsync(
            int employeeId,
            CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .FindAsync([employeeId], cancellationToken);

            if (employee is null)
            {
                throw new DomainException(
                    $"Funcionário {employeeId} não encontrado.");
            }

            return employee;
        }

        public async Task<Product> EnsureProductExistsAsync(
            int productId,
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FindAsync([productId], cancellationToken);

            if (product is null)
            {
                throw new DomainException(
                    $"Produto {productId} não encontrado.");
            }

            return product;
        }

        public async Task<Order> EnsureOrderExistsAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FindAsync([orderId], cancellationToken);

            if (order is null)
            {
                throw new DomainException(
                    $"Pedido {orderId} não encontrado.");
            }

            return order;
        }

        public void EnsureStatus(
            Order order,
            OrderStatusEnum expectedStatus)
        {
            if (order.OrderStatusId != (int)expectedStatus)
            {
                throw new DomainRuleException(
                    $"Pedido deve estar com status '{expectedStatus}'.");
            }
        }

        public OrderItem EnsureOrderItemExists(
            Order order,
            int orderItemId)
        {
            var item = order.OrderItems
                .FirstOrDefault(x => x.Id == orderItemId);

            if (item is null)
            {
                throw new DomainException(
                    $"Item {orderItemId} não encontrado no pedido.");
            }

            return item;
        }

        public async Task EnsureReturnQuantityIsValidAsync(
            Order originalOrder,
            List<CreateReturnOrderItemCommand> items,
            CancellationToken cancellationToken)
        {
            var returnedByProduct =
                await _dbContext.OrderReturns
                    .Where(x => x.OriginalOrderId == originalOrder.Id)
                    .SelectMany(x => x.Items)
                    .GroupBy(x => x.ProductId)
                    .Select(x => new
                    {
                        ProductId = x.Key,
                        Quantity = x.Sum(y => y.Quantity)
                    })
                    .ToDictionaryAsync(
                        x => x.ProductId,
                        x => x.Quantity,
                        cancellationToken);

            foreach (var item in items)
            {
                var dispensedQuantity =
                    originalOrder.OrderItems
                        .Where(x => x.ProductId == item.ProductId)
                        .Sum(x => x.ActualQuantity);

                var returnedQuantity = returnedByProduct.GetValueOrDefault(item.ProductId);

                if (returnedQuantity + item.Quantity > dispensedQuantity)
                {
                    throw new DomainRuleException($"Produto {item.ProductId}: devolução excede a quantidade dispensada.");
                }
            }
        }
    }
}
