using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Finalization;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Services.Orders.Finalization
{
    public class OrderFinalizationService : IOrderFinalizationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderValidationService _validationService;
        private readonly ICurrentUserService _currentUser;

        public OrderFinalizationService(
            IApplicationDbContext dbContext,
            IOrderRepository orderRepository,
            IOrderValidationService validationService,
            ICurrentUserService currentUser)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _validationService = validationService;
            _currentUser = currentUser;
        }

        public async Task<Result<int>> FinalizeAsync(
            FinalizeOrderCommand command,
            CancellationToken cancellationToken)
        {
            await _validationService.EnsureEmployeeExistsAsync(
                    command.FinalizedByEmployeeId,
                    cancellationToken);

            var order = await _orderRepository.GetForFinalizationAsync(
                        command.OrderId,
                        cancellationToken);

            if (order is null)
            {
                throw new DomainException(
                    $"Pedido {command.OrderId} não encontrado.");
            }

            _validationService.EnsureStatus(
                order,
                OrderStatusEnum.ReadyForFinalization);

            var facilityId =
                _currentUser.GetFacilityId();

            if (facilityId is null)
            {
                throw new DomainRuleException(
                    "Usuário não possui unidade associada.");
            }

            if (order.OrderFacilityId != facilityId)
            {
                throw new DomainRuleException(
                    "Operação permitida apenas para a unidade solicitante.");
            }

            order.Finalize(
                employeeId: command.FinalizedByEmployeeId,
                accountId: _currentUser.GetAccountId());

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                order.Id,
                "Pedido finalizado com sucesso.");
        }
    }
}
