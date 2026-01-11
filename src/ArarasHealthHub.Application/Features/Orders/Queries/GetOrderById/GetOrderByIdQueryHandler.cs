using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>
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

        public async Task<ApiResponse<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);

            if (order == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            var currentUser = _httpContextAccessor.HttpContext?.User;
            var scope = currentUser?.FindFirst("Scope")?.Value;
            var facilityClaim = currentUser?.FindFirst("FacilityId")?.Value;

            if (scope == UserScopeEnum.Operational.ToString() && int.TryParse(facilityClaim, out int userFacilityId))
            {
                if (order.OrderFacilityId != userFacilityId)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
                }
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Pedido"), orderDto);
        }
    }
}
