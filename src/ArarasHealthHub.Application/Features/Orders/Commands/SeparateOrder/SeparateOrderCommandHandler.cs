using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Features.Orders.Events;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public class SeparateOrderCommandHandler : IRequestHandler<SeparateOrderCommand, ApiResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockAllocationService _stockAllocationService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SeparateOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IStockAllocationService stockAllocationService,
            IMediator mediator,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _stockAllocationService = stockAllocationService;
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

            if (order.OrderStatusId != (int)OrderStatusEnum.ReadyForPicking)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeSeparated, false);
            }

            var responsible = await _employeeRepo.GetByIdAsync(request.SeparatedByEmployeeId);
            if (responsible == null)
            {
                return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), false);
            }

            var reservedQuantitiesToRelease = new List<(int ProductId, decimal QuantityToRelease)>();

            foreach (var item in request.OrderItems)
            {
                var orderItemToUpdate = order.OrderItems.FirstOrDefault(oi => oi.Id == item.OrderItemId);

                if (orderItemToUpdate == null)
                {
                    return new ApiResponse<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.ItemNotFoundInOrder(item.OrderItemId), false);
                }

                var quantityToSeparate = item.ActualQuantity;
                var reservedQuantity = orderItemToUpdate.ReservedQuantity;

                if (quantityToSeparate > reservedQuantity)
                {
                    return new ApiResponse<OrderDto>(
                        StatusCodes.Status400BadRequest,
                        $"A quantidade separada ({quantityToSeparate}) para o item {item.OrderItemId} excede a quantidade reservada ({reservedQuantity}).",
                        false
                    );
                }

                var allocationResultResponse = await _stockAllocationService.AllocateFeFo(orderItemToUpdate.ProductId, quantityToSeparate);

                if (!allocationResultResponse.Success)
                {
                    return new ApiResponse<OrderDto>(
                        StatusCodes.Status400BadRequest,
                        $"Falha na alocação FEFO para o Produto {orderItemToUpdate.ProductId}: {allocationResultResponse.Message}",
                        false
                    );
                }

                await _stockAllocationService.PerformStockExit(
                    allocationResultResponse.Data!,
                    request.SeparatedByEmployeeId,
                    order.Id,
                    nameof(Order)
                );

                orderItemToUpdate.ActualQuantity = quantityToSeparate;
                reservedQuantitiesToRelease.Add((orderItemToUpdate.ProductId, orderItemToUpdate.ReservedQuantity));
                orderItemToUpdate.ReservedQuantity = 0;
            }

            order.OrderStatusId = (int)OrderStatusEnum.ReadyForFinalization;
            order.SeparatedByEmployeeId = request.SeparatedByEmployeeId;
            order.SeparatedByAccountId = request.SeparatedByAccountId;
            order.SeparatedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            if (reservedQuantitiesToRelease.Any())
            {
                var separationEvent = new OrderItemsSeparatedEvent(
                    order.Id,
                    reservedQuantitiesToRelease
                );
                await _mediator.Publish(separationEvent, cancellationToken);
            }

            _orderRepo.UpdateWithoutSaving(order);

            await _orderRepo.SaveAllAsync(cancellationToken);

            var orderDto = _mapper.Map<OrderDto>(order);

            return new ApiResponse<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("separado"), orderDto);
        }
    }
}
