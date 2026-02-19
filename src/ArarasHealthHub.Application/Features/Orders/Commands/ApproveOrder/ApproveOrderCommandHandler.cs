using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder
{
    public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, ApiResponseO<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ApproveOrderCommandHandler(
            IOrderRepository orderRepo,
            IEmployeeRepository employeeRepo,
            IStockRepository stockRepo,
            IMediator mediator,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _employeeRepo = employeeRepo;
            _stockRepo = stockRepo;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<OrderDto>> Handle(ApproveOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);
            if (order == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }
            if (order.OrderStatusId != (int)OrderStatusEnum.PendingApproval)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeApproved, false);
            }

            var employee = await _employeeRepo.GetByIdAsync(request.ApprovedByEmployeeId, cancellationToken);
            if (employee == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Funcionário de aprovação"), false);
            }

            var itemsToReserve = new List<(int ProductId, decimal Quantity)>();

            foreach (var item in request.OrderItems)
            {
                var orderItemToUpdate = order.OrderItems.FirstOrDefault(oi => oi.Id == item.OrderItemId);

                if (orderItemToUpdate == null) continue;

                var quantityToApprove = item.ApprovedQuantity;

                if (quantityToApprove > orderItemToUpdate.RequestedQuantity)
                {
                    return new ApiResponseO<OrderDto>(
                        StatusCodes.Status400BadRequest,
                        $"A quantidade aprovada ({quantityToApprove}) para o item {item.OrderItemId} não pode exceder a solicitada ({orderItemToUpdate.RequestedQuantity}).",
                        false
                    );
                }

                var stock = await _stockRepo.GetByProductIdAsync(orderItemToUpdate.ProductId);
                if (stock == null)
                {
                    return new ApiResponseO<OrderDto>(
                        StatusCodes.Status404NotFound,
                        $"Estoque não encontrado para o produto {orderItemToUpdate.ProductId}.",
                        false
                    );
                }

                var availableForReservation = stock.CurrentQuantity - stock.ReservedQuantity;

                if (quantityToApprove > availableForReservation)
                {
                    return new ApiResponseO<OrderDto>(
                        StatusCodes.Status400BadRequest,
                        $"Saldo insuficiente para o Produto {orderItemToUpdate.ProductId}. Aprovado: {quantityToApprove}. Disponível: {availableForReservation}.",
                        false
                    );
                }

                itemsToReserve.Add((orderItemToUpdate.ProductId, quantityToApprove));

                orderItemToUpdate.ApprovedQuantity = quantityToApprove;
                orderItemToUpdate.ReservedQuantity = quantityToApprove;
            }

            foreach (var (productId, quantity) in itemsToReserve)
            {
                var reserveResult = await _mediator.Send(new UpdateStockReservationCommand(productId, quantity), cancellationToken);
                if (!reserveResult.Success)
                {
                    return new ApiResponseO<OrderDto>(reserveResult.StatusCode, reserveResult.Message, false);
                }
            }

            order.OrderStatusId = (int)OrderStatusEnum.ReadyForPicking;
            order.ApprovedByEmployeeId = request.ApprovedByEmployeeId;
            order.ApprovedByAccountId = request.ApprovedByAccountId;
            order.ApprovedAt = DateTime.UtcNow;
            order.SetUpdatedOn();

            _orderRepo.UpdateWithoutSaving(order);

            await _orderRepo.SaveAllAsync(cancellationToken);

            var orderDto = _mapper.Map<OrderDto>(order);

            return new ApiResponseO<OrderDto>(StatusCodes.Status200OK, ApiMessages.OrderSuccessfully("aprovado e reservado"), orderDto);
        }
    }
}
