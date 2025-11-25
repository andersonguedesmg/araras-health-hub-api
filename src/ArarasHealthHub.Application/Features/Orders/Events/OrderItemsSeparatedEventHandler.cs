using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Events
{
    public class OrderItemsSeparatedEventHandler : INotificationHandler<OrderItemsSeparatedEvent>
    {
        private readonly IMediator _mediator;

        public OrderItemsSeparatedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderItemsSeparatedEvent notification, CancellationToken cancellationToken)
        {
            foreach (var (productId, quantityToRelease) in notification.ReservedItemsReleased)
            {
                decimal quantityAdjustment = -quantityToRelease;

                try
                {
                    var result = await _mediator.Send(
                        new UpdateStockReservationCommand(productId, quantityAdjustment),
                        cancellationToken
                    );

                    if (!result.Success)
                    {
                        Console.WriteLine($"[WARNING/ERROR] Falha ao liberar reserva para Pedido {notification.OrderId} / Produto {productId}: {result.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CRITICAL ERROR] Exceção ao processar evento de separação de pedido {notification.OrderId}: {ex.Message}");
                }
            }
        }
    }
}
