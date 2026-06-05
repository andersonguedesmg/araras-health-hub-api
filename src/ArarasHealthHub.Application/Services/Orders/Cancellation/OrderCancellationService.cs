using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Cancellation;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Services.Orders.Cancellation
{
    public class OrderCancellationService : IOrderCancellationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderValidationService _validationService;
        private readonly IOrderStockService _stockService;
        private readonly ICurrentUserService _currentUser;

        public OrderCancellationService(
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

        public async Task<Result<int>> CancelAsync(
            CancelOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                    command.CanceledByEmployeeId,
                    cancellationToken);

            var order =
                await _orderRepository.GetForCancellationAsync(
                        command.OrderId,
                        cancellationToken);

            if (order is null)
            {
                throw new DomainException($"Pedido {command.OrderId} não encontrado.");
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.PendingApproval)
            {
                await _stockService.ReleaseReservedItemsAsync(
                    order,
                    cancellationToken);
            }

            order.Cancel(
                command.CancellationReason,
                command.CanceledByEmployeeId,
                _currentUser.GetAccountId());

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                order.Id,
                "Pedido cancelado com sucesso.");
        }
    }
}
