using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement
{
    public class CreateStockMovementCommandHandler : IRequestHandler<CreateStockMovementCommand, ApiResponseO<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public CreateStockMovementCommandHandler(
            IStockMovementRepository stockMovementRepository,
            IMapper mapper
        )
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<StockMovementDto>> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
        {
            var stockMovement = new StockMovement
            {
                Quantity = request.Quantity,
                Type = request.MovementType,
                StockLotId = request.StockLotId,
                SourceDocumentId = request.SourceDocumentId,
                SourceDocumentType = request.SourceDocumentType,
                ResponsibleId = request.ResponsibleId,
                MovementCost = request.MovementCost,
                MovementDate = request.MovementDate,
            };

            await _stockMovementRepository.AddWithoutSavingAsync(stockMovement, cancellationToken);

            var stockMovementDto = _mapper.Map<StockMovementDto>(stockMovement);
            return new ApiResponseO<StockMovementDto>(StatusCodes.Status201Created, ApiMessages.RegisteredSuccessfully("Entrada de estoque"), stockMovementDto);
        }
    }
}
