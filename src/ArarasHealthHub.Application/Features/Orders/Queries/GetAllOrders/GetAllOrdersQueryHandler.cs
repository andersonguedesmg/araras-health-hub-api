using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _orderRepo.GetAllWithItemsAsync(request.OrderStatusId);

            var totalCount = allOrders.Count();

            IOrderedEnumerable<Order> orderedOrders;
            switch (request.OrderBy.ToLower())
            {
                case "createdat":
                    orderedOrders = request.SortOrder.ToLower() == "desc" ?
                        allOrders.OrderByDescending(o => o.CreatedAt) :
                        allOrders.OrderBy(o => o.CreatedAt);
                    break;
                case "id":
                default:
                    orderedOrders = request.SortOrder.ToLower() == "desc" ?
                        allOrders.OrderByDescending(o => o.Id) :
                        allOrders.OrderBy(o => o.Id);
                    break;
            }

            var pagedOrders = orderedOrders
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var orderDtos = _mapper.Map<List<OrderDto>>(pagedOrders);

            return new PagedResponse<OrderDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                orderDtos
            );
        }
    }
}
