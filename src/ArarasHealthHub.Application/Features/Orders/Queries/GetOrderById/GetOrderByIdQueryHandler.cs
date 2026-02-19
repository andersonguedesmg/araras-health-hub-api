using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ApiResponseO<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponseO<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);

            if (order == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), null);
            }

            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scope = currentUser?.FindFirst("Scope")?.Value;
            var facilityClaim = currentUser?.FindFirst("FacilityId")?.Value;

            if (scope == AccountScopeEnum.Operational.ToString() && int.TryParse(facilityClaim, out int userFacilityId))
            {
                if (order.OrderFacilityId != userFacilityId)
                {
                    return new ApiResponseO<OrderDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
                }
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            return new ApiResponseO<OrderDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Pedido"), orderDto);
        }
    }
}
