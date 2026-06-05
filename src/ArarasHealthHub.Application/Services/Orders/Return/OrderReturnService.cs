using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Return;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Services.Orders.Return
{
    public class OrderReturnService : IOrderReturnService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderValidationService _validationService;
        private readonly IOrderStockService _stockService;
        private readonly ICurrentUserService _currentUser;

        public OrderReturnService(
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

        public async Task<Result<int>> CreateAsync(
            CreateReturnOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                command.ReturnedByEmployeeId,
                cancellationToken);

            var order =
                await _orderRepository.GetForReturnAsync(
                    command.OriginalOrderId,
                    cancellationToken);

            if (order is null)
            {
                throw new DomainException(
                    $"Pedido {command.OriginalOrderId} não encontrado.");
            }

            _validationService.EnsureStatus(
                order,
                OrderStatusEnum.Completed);

            var orderReturn =
                new OrderReturn(
                    command.OriginalOrderId,
                    command.Reason,
                    command.ReturnedByEmployeeId,
                    _currentUser.GetAccountId());

            foreach (var item in command.Items)
            {
                var orderItem =
                    order.OrderItems.FirstOrDefault(
                        x => x.ProductId == item.ProductId);

                if (orderItem is null)
                {
                    throw new DomainException(
                        $"Produto {item.ProductId} não encontrado no pedido.");
                }

                await ValidateReturnedQuantityAsync(
                    order,
                    orderItem,
                    item.Quantity,
                    cancellationToken);

                var remainingQuantity =
                    item.Quantity;

                var lots =
                    orderItem.OrderItemLots
                        .OrderByDescending(x => x.Id)
                        .ToList();

                foreach (var lot in lots)
                {
                    if (remainingQuantity <= 0)
                        break;

                    var quantityToReturn =
                        Math.Min(
                            remainingQuantity,
                            lot.Quantity);

                    var stockLot =
                        await _stockService.ProcessStockReturnAsync(
                            stockLotId: lot.StockLotId,
                            quantity: quantityToReturn,
                            responsibleId:
                                command.ReturnedByEmployeeId,
                            sourceDocumentId: 0,
                            sourceDocumentType:
                                nameof(OrderReturn),
                            cancellationToken:
                                cancellationToken);

                    orderReturn.AddItem(
                        new OrderReturnItem(
                            item.ProductId,
                            stockLot.Id,
                            quantityToReturn,
                            stockLot.UnitValue));

                    remainingQuantity -= quantityToReturn;
                }

                if (remainingQuantity > 0)
                {
                    throw new DomainRuleException(
                        $"Não foi possível localizar lotes suficientes para devolver o produto {item.ProductId}.");
                }
            }

            await _dbContext.OrderReturns.AddAsync(
                orderReturn,
                cancellationToken);

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                orderReturn.Id,
                "Devolução registrada com sucesso.");
        }

        private async Task ValidateReturnedQuantityAsync(
            Order order,
            OrderItem orderItem,
            decimal quantityToReturn,
            CancellationToken cancellationToken)
        {
            var alreadyReturned =
                await _dbContext.OrderReturnItems
                    .Where(x =>
                        x.ProductId == orderItem.ProductId &&
                        x.OrderReturn.OriginalOrderId == order.Id)
                    .SumAsync(
                        x => (decimal?)x.Quantity,
                        cancellationToken)
                ?? 0;

            var dispensed =
                orderItem.OrderItemLots
                    .Sum(x => x.Quantity);

            var availableToReturn =
                dispensed - alreadyReturned;

            if (quantityToReturn > availableToReturn)
            {
                throw new DomainRuleException(
                    $"Quantidade devolvida excede o saldo disponível do produto {orderItem.ProductId}. " +
                    $"Disponível para devolução: {availableToReturn}.");
            }
        }
    }
}
