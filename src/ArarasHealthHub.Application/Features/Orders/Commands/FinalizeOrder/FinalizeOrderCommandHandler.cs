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

namespace ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder
{
    public class FinalizeOrderCommandHandler : IRequestHandler<FinalizeOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public FinalizeOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<OrderDto>> Handle(FinalizeOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId);
            if (order == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.Separated)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeCompleted, false);
            }

            var responsible = await _employeeRepo.GetByIdAsync(request.FinalizedByEmployeeId);
            if (responsible == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), false);
            }

            order.OrderStatusId = (int)OrderStatusEnum.Finalized;
            order.FinalizedByEmployeeId = request.FinalizedByEmployeeId;
            order.FinalizedByAccountId = request.FinalizedByAccountId;
            order.FinalizedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            await _orderRepo.UpdateAsync(order);
            await _unitOfWork.CommitAsync();

            var orderDto = new OrderDto
            {
                Id = order.Id,
                Observation = order.Observation,
                OrderStatusId = order.OrderStatusId,
                CreatedAt = order.CreatedAt,
                ApprovedAt = order.ApprovedAt,
                SeparatedAt = order.SeparatedAt,
                FinalizedAt = order.FinalizedAt,

                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    RequestedQuantity = oi.RequestedQuantity,
                    ApprovedQuantity = oi.ApprovedQuantity,
                    ActualQuantity = oi.ActualQuantity,
                    ProductId = oi.ProductId
                }).ToList()
            };
            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("finalizado"), orderDto);
        }
    }
}
