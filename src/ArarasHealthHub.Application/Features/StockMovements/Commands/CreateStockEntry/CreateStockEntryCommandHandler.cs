using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockEntry
{
    public class CreateStockEntryCommandHandler : IRequestHandler<CreateStockEntryCommand, ApiResponse<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public CreateStockEntryCommandHandler(
            IStockMovementRepository stockMovementRepository,
            IMapper mapper
        )
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockMovementDto>> Handle(CreateStockEntryCommand request, CancellationToken cancellationToken)
        {
            var stockMovement = new StockMovement
            {
                Quantity = request.Quantity,
                Type = MovementTypeEnum.Entry,
                StockLotId = request.StockLotId,
                SourceDocumentId = request.SourceDocumentId,
                SourceDocumentType = request.SourceDocumentType,
                ResponsibleId = request.ResponsibleId
            };

            await _stockMovementRepository.AddWithoutSavingAsync(stockMovement);

            var stockMovementDto = _mapper.Map<StockMovementDto>(stockMovement);
            return new ApiResponse<StockMovementDto>(StatusCodes.Status201Created, ApiMessages.RegisteredSuccessfully("Entrada de estoque"), stockMovementDto);
        }
    }
}
