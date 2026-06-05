using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Separation;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Services.Orders.Separation
{
    public class OrderSeparationService : IOrderSeparationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderValidationService _validationService;
        private readonly IOrderStockService _stockService;
        private readonly ICurrentUserService _currentUser;

        public OrderSeparationService(
            IApplicationDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderValidationService validationService,
            IOrderStockService stockService,
            ICurrentUserService currentUser)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _validationService = validationService;
            _stockService = stockService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> SeparateAsync(
            SeparateOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                    command.SeparatedByEmployeeId,
                    cancellationToken);

            var order = await _orderRepository.GetForSeparationAsync(
                    command.OrderId,
                    cancellationToken);

            if (order is null)
            {
                throw new DomainException($"Pedido {command.OrderId} não encontrado.");
            }

            _validationService.EnsureStatus(
                order,
                OrderStatusEnum.ReadyForPicking);

            order.StartSeparation(
                command.SeparatedByEmployeeId,
                _currentUser.GetAccountId());

            foreach (var itemCommand in command.OrderItems)
            {
                var orderItem =
                    _validationService
                        .EnsureOrderItemExists(
                            order,
                            itemCommand.OrderItemId);

                if (itemCommand.ActualQuantity >
                    orderItem.ReservedQuantity)
                {
                    throw new DomainRuleException(
                        $"A quantidade separada ({itemCommand.ActualQuantity}) não pode exceder a quantidade reservada ({orderItem.ReservedQuantity}).");
                }

                var allocations =
                    await _stockService.AllocateFefoAsync(
                        orderItem.ProductId,
                        itemCommand.ActualQuantity,
                        cancellationToken);

                await _stockService.ProcessStockExitAsync(
                    allocations,
                    command.SeparatedByEmployeeId,
                    order.Id,
                    nameof(Order),
                    cancellationToken);

                orderItem.SeparateQuantity(itemCommand.ActualQuantity);

                foreach (var allocation in allocations)
                {
                    orderItem.AddLot(
                        new OrderItemLot(
                            allocation.StockLot.Id,
                            allocation.Quantity,
                            allocation.StockLot.UnitValue));
                }

                var remainingReservation =
                    orderItem.ReservedQuantity -
                    itemCommand.ActualQuantity;

                if (remainingReservation > 0)
                {
                    await _stockService.ReleaseReservationAsync(
                        orderItem.ProductId,
                        remainingReservation,
                        cancellationToken);
                }

                orderItem.ReleaseReservation(
                    orderItem.ReservedQuantity);
            }

            order.CompleteSeparation();

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                order.Id,
                "Pedido separado com sucesso.");
        }
    }
}
