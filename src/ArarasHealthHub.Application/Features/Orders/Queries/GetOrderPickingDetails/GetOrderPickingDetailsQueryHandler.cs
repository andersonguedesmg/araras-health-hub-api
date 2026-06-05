using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Picking;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails
{
    public class GetOrderPickingDetailsQueryHandler : IRequestHandler<
            GetOrderPickingDetailsQuery,
            Result<OrderPickingResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderPickingService _orderPickingService;

        public GetOrderPickingDetailsQueryHandler(
            IOrderRepository orderRepository,
            IOrderPickingService orderPickingService)
        {
            _orderRepository = orderRepository;
            _orderPickingService = orderPickingService;
        }

        public async Task<Result<OrderPickingResponse>> Handle(
            GetOrderPickingDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdForPickingAsync(
                request.Id,
                cancellationToken);

            if (order is null)
            {
                throw new NotFoundException("Pedido não foi encontrado.");
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.ReadyForPicking)
            {
                throw new BadRequestException("Pedido não pode ser separado.");
            }

            var response = await _orderPickingService.BuildPickingAsync(
                order,
                cancellationToken);

            return Result<OrderPickingResponse>.Success(response, "Detalhes da separação carregados com sucesso.");
        }
    }
}
