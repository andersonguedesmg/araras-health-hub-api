using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public class SeparateOrderCommandHandler : IRequestHandler<SeparateOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IUnitOfWork _unitOfWork;

        public SeparateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IStockRepository stockRepo,
            IStockMovementRepository stockMovementRepo,
            IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _stockRepo = stockRepo;
            _stockMovementRepo = stockMovementRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<OrderDto>> Handle(SeparateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);
            if (order == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.Approved)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeSeparated, false);
            }

            var responsible = await _employeeRepo.GetByIdAsync(request.SeparatedByEmployeeId);
            if (responsible == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), false);
            }

            foreach (var item in request.OrderItems)
            {
                var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == item.OrderItemId);
                if (orderItem == null)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.ItemNotFoundInOrder(item.OrderItemId!), false);
                }

                var stock = await _stockRepo.GetByProductIdAsync(orderItem.ProductId);
                if (stock == null || stock.CurrentQuantity < item.ActualQuantity)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.InsufficientStock(orderItem.Product?.Name!), false);
                }
            }

            order.OrderStatusId = (int)OrderStatusEnum.Separated;
            order.SeparatedByEmployeeId = request.SeparatedByEmployeeId;
            order.SeparatedByAccountId = request.SeparatedByAccountId;
            order.SeparatedAt = DateTime.UtcNow;

            var stockMovements = new List<StockMovement>();

            foreach (var item in request.OrderItems)
            {
                var orderItemToUpdate = order.OrderItems.First(oi => oi.Id == item.OrderItemId);
                var stockToUpdate = await _stockRepo.GetByProductIdAsync(orderItemToUpdate.ProductId);

                if (stockToUpdate != null)
                {
                    orderItemToUpdate.ActualQuantity = item.ActualQuantity;
                    stockToUpdate.CurrentQuantity -= item.ActualQuantity;

                    var movement = new StockMovement
                    {
                        ProductId = orderItemToUpdate.ProductId,
                        Quantity = item.ActualQuantity,
                        Type = MovementTypeEnum.Entry,
                        SourceDocumentId = order.Id,
                        SourceDocumentType = nameof(Order),
                        ResponsibleId = request.SeparatedByEmployeeId
                    };
                    stockMovements.Add(movement);
                }
            }

            await _stockMovementRepo.AddRangeAsync(stockMovements);
            await _unitOfWork.CommitAsync();

            var orderDto = new OrderDto
            {
                Id = order.Id,
                Observation = order.Observation,
                OrderStatusId = order.OrderStatusId,
                CreatedAt = order.CreatedAt,
                ApprovedAt = order.ApprovedAt,
                SeparatedAt = order.SeparatedAt,

                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    RequestedQuantity = oi.RequestedQuantity,
                    ApprovedQuantity = oi.ApprovedQuantity,
                    ActualQuantity = oi.ActualQuantity,
                    ProductId = oi.ProductId
                }).ToList()
            };
            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("separado"), orderDto);
        }
    }
}
