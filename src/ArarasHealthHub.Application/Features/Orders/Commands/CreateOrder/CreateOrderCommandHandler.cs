using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ApiResponseO<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            UserManager<ApplicationUser> userManager,
            IProductRepository productRepo,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _userManager = userManager;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetByIdAsync(request.CreatedByEmployeeId, cancellationToken);
            if (employee == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Funcionário"), null);
            }

            var account = await _userManager.FindByIdAsync(request.CreatedByAccountId.ToString());
            if (account == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            var facilityId = account.FacilityId;

            if (facilityId <= 0)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status403Forbidden, ApiMessages.UnableToIdentifyFacilityOfTheLoggedAccount, false);
            }

            var orderItems = new List<OrderItem>();

            foreach (var itemDto in request.OrderItems)
            {
                var product = await _productRepo.GetByIdAsync(itemDto.ProductId, cancellationToken);
                if (product == null)
                {
                    return new ApiResponseO<OrderDto>(
                        StatusCodes.Status404NotFound,
                        ApiMessages.NotFoundWithId("Produto", itemDto.ProductId),
                        false
                    );
                }

                var orderItem = new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    RequestedQuantity = itemDto.RequestedQuantity,
                    ApprovedQuantity = 0,
                    ReservedQuantity = 0,
                    ActualQuantity = 0
                };
                orderItems.Add(orderItem);
            }

            var order = new Order
            {
                Observation = request.Observation,
                CreatedAt = DateTime.UtcNow,
                CreatedByEmployeeId = request.CreatedByEmployeeId,
                CreatedByAccountId = request.CreatedByAccountId,
                OrderStatusId = (int)OrderStatusEnum.PendingApproval,
                OrderFacilityId = facilityId,
                OrderItems = orderItems
            };

            await _orderRepo.AddAsync(order, cancellationToken);

            var createdOrderWithDetails = await _orderRepo.GetByIdWithItemsAsync(order.Id);

            if (createdOrderWithDetails == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status500InternalServerError, ApiMessages.InternalServerError, false);
            }

            var orderDto = _mapper.Map<OrderDto>(createdOrderWithDetails);

            return new ApiResponseO<OrderDto>(
                StatusCodes.Status201Created,
                ApiMessages.CreatedSuccessfully("Pedido"),
                orderDto
            );
        }
    }
}
