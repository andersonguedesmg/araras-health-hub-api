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

        public CreateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _productRepo = productRepo;
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

            var orderItems = request.OrderItems.Select(itemDto => new OrderItem
            {
                OrderId = order.Id,
                ProductId = itemDto.ProductId,
                RequestedQuantity = itemDto.RequestedQuantity,
                ApprovedQuantity = 0,
                ActualQuantity = 0
            }).ToList();

            foreach (var orderItem in orderItems)
            {
                await _orderRepo.CreateOrderItemAsync(orderItem);
            }

            await _unitOfWork.CommitAsync();

            var orderDto = new OrderDto
            {
                Id = order.Id,
                Observation = order.Observation,
                OrderStatusId = order.OrderStatusId,
                CreatedByEmployeeId = order.CreatedByEmployeeId,
                CreatedByAccountId = order.CreatedByAccountId,
                CreatedAt = order.CreatedAt,
                OrderItems = orderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    RequestedQuantity = oi.RequestedQuantity
                }).ToList()
            };

            return new ApiResponse<OrderDto>(
                StatusCodes.Status201Created,
                ApiMessages.CreatedSuccessfully("Pedido"),
                orderDto
            );
        }
    }
}
