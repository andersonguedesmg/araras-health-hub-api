using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public class SeparateOrderCommandHandler : IRequestHandler<SeparateOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockLotRepository _stockLotRepo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SeparateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IStockRepository stockRepo,
            IStockMovementRepository stockMovementRepo,
            IUnitOfWork unitOfWork,
            IStockLotRepository stockLotRepo,
            IMediator mediator,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _stockRepo = stockRepo;
            _stockMovementRepo = stockMovementRepo;
            _unitOfWork = unitOfWork;
            _stockLotRepo = stockLotRepo;
            _mediator = mediator;
            _mapper = mapper;
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

                var stockToVerify = await _stockRepo.GetByProductIdAsync(orderItem.ProductId);
                if (stockToVerify == null || stockToVerify.CurrentQuantity < item.ActualQuantity)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.InsufficientStock(stockToVerify?.Product?.Name ?? "produto desconhecido"), false);
                }
            }

            order.OrderStatusId = (int)OrderStatusEnum.Separated;
            order.SeparatedByEmployeeId = request.SeparatedByEmployeeId;
            order.SeparatedByAccountId = request.SeparatedByAccountId;
            order.SeparatedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            var stockMovements = new List<StockMovement>();

            foreach (var item in request.OrderItems)
            {
                var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == item.OrderItemId);
                var stockToVerify = await _stockRepo.GetByProductIdAsync(orderItem!.ProductId);
                if (stockToVerify == null || stockToVerify.CurrentQuantity < item.ActualQuantity)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.InsufficientStock(stockToVerify?.Product?.Name ?? "produto desconhecido"), false);
                }
            }

            foreach (var item in request.OrderItems)
            {
                var orderItemToUpdate = order.OrderItems.First(oi => oi.Id == item.OrderItemId);
                var quantityToSeparate = item.ActualQuantity;
                var availableLots = await _stockLotRepo.AsQueryable()
                    .Include(sl => sl.Stock)
                    .Where(sl => sl.Stock.ProductId == orderItemToUpdate.ProductId && sl.AvailableQuantity > 0)
                    .OrderBy(sl => sl.CreatedOn) // FIFO
                    .ToListAsync(cancellationToken);

                decimal remainingQuantity = quantityToSeparate;

                foreach (var lot in availableLots)
                {
                    if (remainingQuantity <= 0) break;

                    decimal quantityFromThisLot = Math.Min(remainingQuantity, lot.AvailableQuantity);

                    lot.RemoveQuantity(quantityFromThisLot);
                    _stockLotRepo.UpdateWithoutSaving(lot);

                    stockMovements.Add(new StockMovement
                    {
                        StockLotId = lot.Id,
                        Quantity = quantityFromThisLot,
                        Type = MovementTypeEnum.Exit,
                        SourceDocumentId = order.Id,
                        SourceDocumentType = nameof(Order),
                        ResponsibleId = request.SeparatedByEmployeeId
                    });

                    var updateStockCommand = new UpdateProductStockCommand(
                        orderItemToUpdate.ProductId,
                        quantityFromThisLot,
                        StockOperationTypeEnum.Dispatch
                    );
                    await _mediator.Send(updateStockCommand, cancellationToken);

                    remainingQuantity -= quantityFromThisLot;
                }

                orderItemToUpdate.ActualQuantity = item.ActualQuantity;

                if (remainingQuantity > 0)
                {
                    throw new ApplicationException($"Falha crítica na separação de pedido: Lotes insuficientes para o Produto {orderItemToUpdate.ProductId}.");
                }
            }

            order.OrderStatusId = (int)OrderStatusEnum.Separated;
            order.SeparatedByEmployeeId = request.SeparatedByEmployeeId;
            order.SeparatedByAccountId = request.SeparatedByAccountId;
            order.SeparatedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            await _orderRepo.UpdateAsync(order);
            await _stockMovementRepo.AddRangeAsync(stockMovements);
            await _unitOfWork.CommitAsync();

            var orderDto = _mapper.Map<OrderDto>(order);
            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("separado"), orderDto);
        }
    }
}
