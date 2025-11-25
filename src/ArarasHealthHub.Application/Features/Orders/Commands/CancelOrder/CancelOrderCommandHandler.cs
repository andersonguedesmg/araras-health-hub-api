using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, ApiResponse<bool>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMediator _mediator;

        public CancelOrderCommandHandler(IOrderRepository orderRepo, IMediator mediator)
        {
            _orderRepo = orderRepo;
            _mediator = mediator;
        }

        public async Task<ApiResponse<bool>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.OrderId);

            if (order == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            var orderStatus = (OrderStatusEnum)order.OrderStatusId;

            if (orderStatus == OrderStatusEnum.Completed || orderStatus == OrderStatusEnum.ReadyForFinalization)
            {
                return new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.CannotCancelOrderInStatus(orderStatus.ToString()), false);
            }

            if (orderStatus == OrderStatusEnum.Cancelled)
            {
                return new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.OrderAlreadyCancelled, false);
            }

            if (orderStatus != OrderStatusEnum.PendingApproval)
            {
                var itemsToRelease = order.OrderItems.Where(oi => oi.ReservedQuantity > 0).ToList();

                var releaseTasks = new List<Task<ApiResponse<bool>>>();

                foreach (var item in itemsToRelease)
                {
                    decimal quantityAdjustment = -item.ReservedQuantity;
                    var releaseCommand = new UpdateStockReservationCommand(item.ProductId, quantityAdjustment);
                    releaseTasks.Add(_mediator.Send(releaseCommand, cancellationToken));
                    item.ReservedQuantity = 0;
                }

                var releaseResults = await Task.WhenAll(releaseTasks);

                if (releaseResults.Any(r => !r.Success))
                {
                    return new ApiResponse<bool>(
                       StatusCodes.Status500InternalServerError,
                       ApiMessages.StockReleaseFailed,
                       false
                   );
                }
            }

            order.OrderStatusId = (int)OrderStatusEnum.Cancelled;
            order.CanceledByEmployeeId = request.CanceledByEmployeeId;
            order.CanceledByAccountId = request.CanceledByAccountId;
            order.CancellationReason = request.CancellationReason;
            order.CanceledAt = DateTime.UtcNow;

            _orderRepo.UpdateWithoutSaving(order);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.OrderCancelledSuccessfully, true);
        }
    }
}
