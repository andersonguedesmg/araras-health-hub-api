using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Creation;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Services.Orders.Creation
{
    public class OrderCreationService : IOrderCreationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOrderValidationService _validationService;

        public OrderCreationService(
            IApplicationDbContext dbContext,
            IOrderRepository orderRepository,
            ICurrentUserService currentUserService,
            IOrderValidationService validationService)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
            _validationService = validationService;
        }

        public async Task<Result<int>> CreateOrderAsync(
            CreateOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                    command.CreatedByEmployeeId,
                    cancellationToken);

            var facilityId =
                _currentUserService.GetFacilityId();

            if (!facilityId.HasValue)
            {
                throw new DomainException(
                    "Conta autenticada não possui unidade vinculada."
                );
            }

            var accountId =
                _currentUserService.GetAccountId();

            var order = new Order(
                facilityId: facilityId.Value,
                employeeId: command.CreatedByEmployeeId,
                accountId: accountId,
                observation: command.Observation
            );

            foreach (var itemCommand in command.Items)
            {
                await _validationService.EnsureProductExistsAsync(
                        itemCommand.ProductId,
                        cancellationToken);

                var orderItem = new OrderItem(
                    productId: itemCommand.ProductId,
                    requestedQuantity:
                        itemCommand.RequestedQuantity
                );

                order.AddItem(orderItem);
            }

            await _orderRepository.AddAsync(
                order,
                cancellationToken);

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                order.Id,
                "Pedido criado com sucesso."
            );
        }
    }
}
