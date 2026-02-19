using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById
{
    public class GetStockMovementByIdQueryHandler : IRequestHandler<GetStockMovementByIdQuery, ApiResponseO<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public GetStockMovementByIdQueryHandler(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<StockMovementDto>> Handle(GetStockMovementByIdQuery request, CancellationToken cancellationToken)
        {
            var movement = await _stockMovementRepository.GetByIdAsync(request.Id, cancellationToken);

            if (movement == null)
            {
                return new ApiResponseO<StockMovementDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Movimento de estoque"), null);
            }

            var movementDto = _mapper.Map<StockMovementDto>(movement);
            return new ApiResponseO<StockMovementDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Movimento de estoque"), movementDto);
        }
    }
}
