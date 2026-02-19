using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder
{
    public class FinalizeOrderCommandHandler : IRequestHandler<FinalizeOrderCommand, ApiResponseO<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FinalizeOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApiResponseO<OrderDto>> Handle(FinalizeOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);

            if (order == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.ReadyForFinalization)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeCompleted, false);
            }

            var responsible = await _employeeRepo.GetByIdAsync(request.FinalizedByEmployeeId, cancellationToken);
            if (responsible == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), false);
            }

            var applicationUser = await _userManager.FindByIdAsync(request.FinalizedByAccountId.ToString());

            if (applicationUser == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            var currentUser = _httpContextAccessor.HttpContext?.User;
            var userFacilityClaim = currentUser?.FindFirst("FacilityId");

            if (userFacilityClaim == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
            }

            if (order.OrderFacilityId != applicationUser.FacilityId)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status403Forbidden, ApiMessages.OperationRestrictedToFacility, false);
            }

            order.OrderStatusId = (int)OrderStatusEnum.Completed;
            order.FinalizedByEmployeeId = request.FinalizedByEmployeeId;
            order.FinalizedByAccountId = request.FinalizedByAccountId;
            order.FinalizedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            _orderRepo.UpdateWithoutSaving(order);
            await _orderRepo.SaveAllAsync(cancellationToken);
            var orderDto = _mapper.Map<OrderDto>(order);

            return new ApiResponseO<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("finalizado"), orderDto);
        }
    }
}
