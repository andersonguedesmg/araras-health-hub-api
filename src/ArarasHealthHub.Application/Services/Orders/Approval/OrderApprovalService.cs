using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Approval;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Services.Orders.Approval
{
    public class OrderApprovalService : IOrderApprovalService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOrderValidationService _validationService;
        private readonly IOrderStockService _orderStockService;

        public OrderApprovalService(
            IApplicationDbContext dbContext,
            IOrderRepository orderRepository,
            ICurrentUserService currentUserService,
            IOrderValidationService validationService,
            IOrderStockService orderStockService)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
            _validationService = validationService;
            _orderStockService = orderStockService;
        }

        public async Task<Result<int>> ApproveOrderAsync(
            ApproveOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                    command.ApprovedByEmployeeId,
                    cancellationToken);

            var order =
                await _orderRepository.GetForApprovalAsync(
                    command.OrderId,
                    cancellationToken);

            if (order is null)
            {
                throw new DomainException(
                    $"Pedido {command.OrderId} não encontrado.");
            }

            _validationService.EnsureStatus(
                order,
                OrderStatusEnum.PendingApproval);

            foreach (var itemCommand in command.Items)
            {
                var orderItem =
                    _validationService
                        .EnsureOrderItemExists(
                            order,
                            itemCommand.OrderItemId);

                orderItem.ApproveQuantity(
                    itemCommand.ApprovedQuantity);
            }

            await _orderStockService
                .ReserveApprovedItemsAsync(
                    order,
                    cancellationToken);

            order.Approve(
                employeeId: command.ApprovedByEmployeeId,
                accountId: _currentUserService.GetAccountId());

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                order.Id,
                "Pedido aprovado com sucesso.");
        }
    }
}
