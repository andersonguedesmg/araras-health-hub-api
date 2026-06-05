using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Shared
{
    public interface IOrderValidationService
    {
        Task<Employee> EnsureEmployeeExistsAsync(
            int employeeId,
            CancellationToken cancellationToken);

        Task<Product> EnsureProductExistsAsync(
            int productId,
            CancellationToken cancellationToken);

        Task<Order> EnsureOrderExistsAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task EnsureReturnQuantityIsValidAsync(
            Order originalOrder,
            List<CreateReturnOrderItemCommand> items,
            CancellationToken cancellationToken);

        void EnsureStatus(
            Order order,
            OrderStatusEnum expectedStatus);

        OrderItem EnsureOrderItemExists(
            Order order,
            int orderItemId);
    }
}
