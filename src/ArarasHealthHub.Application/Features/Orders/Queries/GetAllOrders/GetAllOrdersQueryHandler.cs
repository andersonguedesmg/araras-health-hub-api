using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResponse<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scope = currentUser?.FindFirst("Scope")?.Value;
            var facilityClaim = currentUser?.FindFirst("FacilityId")?.Value;
            int? facilityIdToFilter = null;

            if (scope == UserScopeEnum.Operational.ToString() && int.TryParse(facilityClaim, out int facilityId))
            {
                facilityIdToFilter = facilityId;
            }

            var allOrders = await _orderRepo.GetAllWithItemsAsync(request.OrderStatusId, facilityIdToFilter);
            var totalCount = allOrders.Count();

            IOrderedEnumerable<Order> orderedOrders;
            switch (request.OrderBy?.ToLower())
            {
                case "createdat":
                    orderedOrders = request.SortOrder?.ToLower() == "desc" ?
                        allOrders.OrderByDescending(o => o.CreatedAt) :
                        allOrders.OrderBy(o => o.CreatedAt);
                    break;
                case "id":
                default:
                    orderedOrders = request.SortOrder?.ToLower() == "desc" ?
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
