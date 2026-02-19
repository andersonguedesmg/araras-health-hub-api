using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation
{
    public class UpdateStockReservationCommandHandler : IRequestHandler<UpdateStockReservationCommand, ApiResponseO<bool>>
    {
        private readonly IStockRepository _stockRepo;
        private readonly IStockLotRepository _stockLotRepo;

        public UpdateStockReservationCommandHandler(IStockRepository stockRepo, IStockLotRepository stockLotRepo)
        {
            _stockRepo = stockRepo;
            _stockLotRepo = stockLotRepo;
        }

        public async Task<ApiResponseO<bool>> Handle(UpdateStockReservationCommand request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepo.GetByProductIdAsync(request.ProductId);

            if (stock == null)
            {
                return new ApiResponseO<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Estoque para Produto", request.ProductId), false);
            }

            if (request.QuantityToReserve > 0 && (stock.AvailableQuantity < request.QuantityToReserve))
            {
                return new ApiResponseO<bool>(
                    StatusCodes.Status400BadRequest,
                    $"Não é possível reservar {request.QuantityToReserve} unidades. Saldo disponível (Não reservado): {stock.AvailableQuantity}.",
                    false
                );
            }

            stock.ReservedQuantity += request.QuantityToReserve;
            stock.AvailableQuantity = stock.CurrentQuantity - stock.ReservedQuantity;

            _stockRepo.UpdateWithoutSaving(stock);

            return new ApiResponseO<bool>(StatusCodes.Status200OK, "Reserva de estoque atualizada com sucesso.", true);
        }
    }
}
