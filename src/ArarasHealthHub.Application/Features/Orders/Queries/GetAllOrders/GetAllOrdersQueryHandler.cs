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
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedResponseO<OrderDto>>
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

        public async Task<PagedResponseO<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scopeClaim = currentUser?.FindFirst("Scope")?.Value;

            var query = _orderRepo.GetQueryable();

            if (scopeClaim == AccountScopeEnum.Operational.ToString())
            {
                var accountIdClaim = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (accountIdClaim != null && int.TryParse(accountIdClaim, out int accountId))
                {
                    var account = await _userManager.FindByIdAsync(accountId.ToString());
                    if (account != null && account.FacilityId != 0)
                    {
                        query = query.Where(o => o.OrderFacilityId == account!.FacilityId);
                    }
                }
            }

            if (request.OrderStatusId.HasValue)
            {
                query = query.Where(o => o.OrderStatusId == request.OrderStatusId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(o =>
                    o.Id.ToString().Contains(searchTermLower) ||
                    o.OrderFacility!.Name.ToLower().Contains(searchTermLower) ||
                    o.CreatedByEmployee!.Name.ToLower().Contains(searchTermLower) ||
                    (o.CancellationReason != null && o.CancellationReason.ToLower().Contains(searchTermLower))
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            IQueryable<Order> orderedQuery;
            switch (request.OrderBy?.ToLower())
            {
                case "createdat":
                    orderedQuery = request.SortOrder?.ToLower() == "desc" ?
                        query.OrderByDescending(o => o.CreatedAt) :
                        query.OrderBy(o => o.CreatedAt);
                    break;
                case "facility":
                    orderedQuery = request.SortOrder?.ToLower() == "desc" ?
                        query.OrderByDescending(o => o.OrderFacility!.Name) :
                        query.OrderBy(o => o.OrderFacility!.Name);
                    break;
                case "id":
                default:
                    orderedQuery = request.SortOrder?.ToLower() == "desc" ?
                        query.OrderByDescending(o => o.Id) :
                        query.OrderBy(o => o.Id);
                    break;
            }

            var pagedOrders = await orderedQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(o => o.OrderItems)
                .Include(o => o.OrderFacility)
                .Include(o => o.CreatedByEmployee)
                .Include(o => o.OrderStatus)
                .ToListAsync(cancellationToken);

            var orderDtos = _mapper.Map<List<OrderDto>>(pagedOrders);

            return new PagedResponseO<OrderDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                orderDtos
            );
        }
    }
}
