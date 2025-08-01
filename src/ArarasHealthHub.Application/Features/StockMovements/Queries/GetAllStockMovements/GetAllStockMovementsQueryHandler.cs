using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements
{
    public class GetAllStockMovementsQueryHandler : IRequestHandler<GetAllStockMovementsQuery, PagedResponse<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public GetAllStockMovementsQueryHandler(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockMovementDto>> Handle(GetAllStockMovementsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _stockMovementRepository.GetTotalCountAsync();
            var movements = await _stockMovementRepository.GetAllAsync(
                request.PageNumber,
                request.PageSize,
                request.OrderBy,
                request.SortOrder
            );

            var movementDtos = _mapper.Map<List<StockMovementDto>>(movements);

            return new PagedResponse<StockMovementDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                movementDtos
            );
        }
    }
}
