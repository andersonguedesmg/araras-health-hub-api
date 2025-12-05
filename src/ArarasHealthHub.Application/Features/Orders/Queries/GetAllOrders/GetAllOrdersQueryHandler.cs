using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetAllOrdersQueryHandler(
            IOrderRepository orderRepo,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<PagedResponse<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scopeClaim = currentUser?.FindFirst("Scope")?.Value;
            int? facilityIdToFilter = null;

            if (scopeClaim == UserScopeEnum.Operational.ToString())
            {
                var accountIdClaim = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (accountIdClaim != null && int.TryParse(accountIdClaim, out int accountId))
                {
                    var account = await _userManager.FindByIdAsync(accountId.ToString());

                    if (account != null)
                    {
                        facilityIdToFilter = account.FacilityId;
                    }
                }
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
