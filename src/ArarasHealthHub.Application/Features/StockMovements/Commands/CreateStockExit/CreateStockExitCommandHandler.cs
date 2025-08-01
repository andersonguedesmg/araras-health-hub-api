using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockExit
{
    public class CreateStockExitCommandHandler : IRequestHandler<CreateStockExitCommand, ApiResponse<StockMovementDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateStockExitCommandHandler(
            IApplicationDbContext dbContext,
            IStockMovementRepository stockMovementRepository,
            IMediator mediator,
            IMapper mapper
        )
        {
            _dbContext = dbContext;
            _stockMovementRepository = stockMovementRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockMovementDto>> Handle(CreateStockExitCommand request, CancellationToken cancellationToken)
        {
            var stockMovement = new StockMovement
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Type = MovementTypeEnum.Exit,
                SourceDocumentId = request.SourceDocumentId,
                SourceDocumentType = request.SourceDocumentType,
                ResponsibleId = request.ResponsibleId
            };

            await _stockMovementRepository.AddWithoutSavingAsync(stockMovement);

            var updateCommand = new UpdateProductStockCommand(
                request.ProductId,
                request.Quantity,
                StockOperationTypeEnum.Dispatch
            );
            await _mediator.Send(updateCommand, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var stockMovementDto = _mapper.Map<StockMovementDto>(stockMovement);
            return new ApiResponse<StockMovementDto>(StatusCodes.Status201Created, ApiMessages.RegisteredSuccessfully("Saída de estoque"), stockMovementDto);
        }
    }
}
