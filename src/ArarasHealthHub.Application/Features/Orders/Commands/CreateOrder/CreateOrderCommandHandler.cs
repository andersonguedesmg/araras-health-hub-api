using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IProductRepository productRepo,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.GetByIdAsync(request.CreatedByEmployeeId);
            if (employee == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Funcionário"), false);
            }

            var account = await _userManager.FindByIdAsync(request.CreatedByAccountId.ToString());
            if (account == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            foreach (var itemDto in request.OrderItems)
            {
                var product = await _productRepo.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                {
                    return new ApiResponse<OrderDto>(
                        StatusCodes.Status404NotFound,
                        ApiMessages.NotFoundWithId("Produto", itemDto.ProductId),
                        false
                    );
                }
            }

            var order = new Order
            {
                Observation = request.Observation,
                CreatedAt = DateTime.UtcNow,
                CreatedByEmployeeId = request.CreatedByEmployeeId,
                CreatedByAccountId = request.CreatedByAccountId,
                OrderStatusId = (int)OrderStatusEnum.Pending
            };

            await _orderRepo.AddAsync(order);
            await _unitOfWork.CommitAsync();

            foreach (var itemDto in request.OrderItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = itemDto.ProductId,
                    RequestedQuantity = itemDto.RequestedQuantity,
                    ApprovedQuantity = 0,
                    ActualQuantity = 0
                };
                await _orderRepo.CreateOrderItemAsync(orderItem);
            }

            await _unitOfWork.CommitAsync();

            var createdOrderWithDetails = await _orderRepo.GetByIdWithItemsAsync(order.Id);

            if (createdOrderWithDetails == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status500InternalServerError, ApiMessages.InternalServerError, false);
            }

            var orderDto = _mapper.Map<OrderDto>(createdOrderWithDetails);

            return new ApiResponse<OrderDto>(
                StatusCodes.Status201Created,
                ApiMessages.CreatedSuccessfully("Pedido"),
                orderDto
            );
        }
    }
}
