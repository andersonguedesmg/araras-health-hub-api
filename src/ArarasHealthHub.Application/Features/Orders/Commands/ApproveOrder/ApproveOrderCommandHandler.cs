using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder
{
    public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<OrderDto>> Handle(ApproveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);
            if (order == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }
            if (order.OrderStatusId != (int)OrderStatusEnum.Pending)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeApproved, false);
            }

            var employee = await _employeeRepo.GetByIdAsync(request.ApprovedByEmployeeId);
            if (employee == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Funcionário de aprovação"), false);
            }

            order.OrderStatusId = (int)OrderStatusEnum.Approved;
            order.ApprovedByEmployeeId = request.ApprovedByEmployeeId;
            order.ApprovedByAccountId = request.ApprovedByAccountId;
            order.ApprovedAt = DateTime.UtcNow;

            foreach (var item in request.OrderItems)
            {
                var orderItemToUpdate = order.OrderItems.FirstOrDefault(oi => oi.Id == item.OrderItemId);
                if (orderItemToUpdate != null)
                {
                    orderItemToUpdate.ApprovedQuantity = item.ApprovedQuantity;
                }
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
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    RequestedQuantity = oi.RequestedQuantity,
                    ProductId = oi.ProductId
                }).ToList()
            };
            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderApprovedSuccessfully, orderDto);
        }
    }
}
