using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<OrderResponse>> Handle(
            GetOrderByIdQuery request,
            CancellationToken cancellationToken)
        {
            var order =
                await _orderRepository.GetDetailsAsync(
                        request.Id,
                        cancellationToken);

            if (order is null)
            {
                throw new NotFoundException("Pedido não foi encontrado.");
            }

            var response = _mapper.Map<OrderResponse>(order);

            return Result<OrderResponse>.Success(
                response,
                "Pedido encontrado com sucesso.");
        }
    }
}
