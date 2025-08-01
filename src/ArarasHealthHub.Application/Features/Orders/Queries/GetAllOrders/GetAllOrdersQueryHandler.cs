using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ApiResponse<List<OrderDto>>>
    {
        private readonly IOrderRepository _orderRepo;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<ApiResponse<List<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetAllAsync();

            if (orders == null || !orders.Any())
            {
                return new ApiResponse<List<OrderDto>>(StatusCodes.Status404NotFound, ApiMessages.NotItemsFound("pedido"), false);
            }

            var orderDtos = orders.Select(order => new OrderDto
            {
                Id = order.Id,
                Observation = order.Observation,
                OrderStatusId = order.OrderStatusId,
                CreatedByEmployeeId = order.CreatedByEmployeeId,
                CreatedByAccountId = order.CreatedByAccountId,
                CreatedAt = order.CreatedAt,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    RequestedQuantity = oi.RequestedQuantity,
                    ProductId = oi.ProductId
                }).ToList()
            }).ToList();

            return new ApiResponse<List<OrderDto>>(StatusCodes.Status200OK, ApiMessages.ItemsFoundSuccessfully("Pedidos"), orderDtos);
        }
    }
}
