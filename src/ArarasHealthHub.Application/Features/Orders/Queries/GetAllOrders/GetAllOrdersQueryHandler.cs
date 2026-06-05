using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedResult<OrderListItemResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllOrdersQueryHandler(
            IOrderRepository orderRepository,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResult<OrderListItemResponse>> Handle(
            GetAllOrdersQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Order> query =
                _orderRepository
                    .AsQueryable()
                    .AsNoTracking()
                    .Include(x => x.OrderFacility)
                    .Include(x => x.CreatedByEmployee)
                    .Include(x => x.OrderStatus)
                    .Include(x => x.OrderItems);

            var currentUser =
                _httpContextAccessor.HttpContext?.User;

            var scope =
                currentUser?.FindFirst("Scope")?.Value;

            if (scope == AccountScopeEnum.Operational.ToString())
            {
                var accountIdClaim =
                    currentUser?.FindFirst(
                        ClaimTypes.NameIdentifier)
                    ?.Value;

                if (int.TryParse(
                        accountIdClaim,
                        out var accountId))
                {
                    var account =
                        await _userManager.FindByIdAsync(
                            accountId.ToString());

                    if (account?.FacilityId > 0)
                    {
                        query = query.Where(x =>
                            x.OrderFacilityId ==
                            account.FacilityId);
                    }
                }
            }

            if (request.OrderStatusId.HasValue)
            {
                query = query.Where(x =>
                    x.OrderStatusId ==
                    request.OrderStatusId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Id.ToString(), $"%{term}%") ||
                    EF.Functions.Like(x.OrderFacility!.Name, $"%{term}%") ||
                    EF.Functions.Like(x.CreatedByEmployee!.Name, $"%{term}%") ||
                    (x.CancellationReason != null && EF.Functions.Like(x.CancellationReason, $"%{term}%")));
            }

            var totalCount =
                await query.CountAsync(
                    cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "facility" =>
                    request.SortOrder == "desc"
                        ? query.OrderByDescending(
                            x => x.OrderFacility!.Name)
                        : query.OrderBy(
                            x => x.OrderFacility!.Name),

                "status" =>
                    request.SortOrder == "desc"
                        ? query.OrderByDescending(
                            x => x.OrderStatus!.Description)
                        : query.OrderBy(
                            x => x.OrderStatus!.Description),

                "createdon" =>
                    request.SortOrder == "desc"
                        ? query.OrderByDescending(
                            x => x.CreatedOn)
                        : query.OrderBy(
                            x => x.CreatedOn),

                _ =>
                    request.SortOrder == "desc"
                        ? query.OrderByDescending(
                            x => x.Id)
                        : query.OrderBy(
                            x => x.Id)
            };

            var items =
                await query
                    .Skip(
                        (request.PageNumber - 1)
                        * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x =>
                        new OrderListItemResponse(
                            x.Id,

                            x.OrderStatusId,
                            x.OrderStatus!.Description,

                            x.OrderFacilityId,
                            x.OrderFacility!.Name,

                            x.CreatedByEmployeeId,
                            x.CreatedByEmployee!.Name,

                            x.OrderItems.Count,

                            x.CreatedOn,
                            x.IsActive))
                    .ToListAsync(
                        cancellationToken);

            return PagedResult<OrderListItemResponse>
                .Success(
                    items,
                    request.PageNumber,
                    request.PageSize,
                    totalCount,
                    "Pedidos listados com sucesso.");
        }
    }
}
