using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById
{
    public class GetStockMovementByIdQueryHandler : IRequestHandler<GetStockMovementByIdQuery, ApiResponse<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public GetStockMovementByIdQueryHandler(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockMovementDto>> Handle(GetStockMovementByIdQuery request, CancellationToken cancellationToken)
        {
            var movement = await _stockMovementRepository.GetByIdAsync(request.Id);

            if (movement == null)
            {
                return new ApiResponse<StockMovementDto>(StatusCodes.Status404NotFound, "Movimento de estoque não encontrado.", false);
            }

            var movementDto = _mapper.Map<StockMovementDto>(movement);
            return new ApiResponse<StockMovementDto>(StatusCodes.Status200OK, "Movimento de estoque recuperado com sucesso.", movementDto);
        }
    }
}
