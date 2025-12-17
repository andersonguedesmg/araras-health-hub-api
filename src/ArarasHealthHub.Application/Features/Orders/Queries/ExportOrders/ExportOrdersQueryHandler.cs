using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Orders.Queries.ExportOrders
{
    public class ExportOrdersQueryHandler : IRequestHandler<ExportOrdersQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExportOrdersQueryHandler(
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

        public async Task<IEnumerable<OrderDto>> Handle(ExportOrdersQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scopeClaim = currentUser?.FindFirst("Scope")?.Value;

            var query = _orderRepo.GetQueryable();

            if (scopeClaim == UserScopeEnum.Operational.ToString())
            {
                var accountIdClaim = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (accountIdClaim != null && int.TryParse(accountIdClaim, out int accountId))
                {
                    var account = await _userManager.FindByIdAsync(accountId.ToString());
                    if (account?.FacilityId != null)
                    {
                        query = query.Where(o => o.OrderFacilityId == account.FacilityId);
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
                    o.CreatedByEmployee!.Name.ToLower().Contains(searchTermLower));
            }

            var orders = await query
                .Include(o => o.OrderFacility)
                .Include(o => o.CreatedByEmployee)
                .Include(o => o.OrderStatus)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}
