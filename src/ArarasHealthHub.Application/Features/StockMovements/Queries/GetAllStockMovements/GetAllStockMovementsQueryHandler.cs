using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements
{
    public class GetAllStockMovementsQueryHandler : IRequestHandler<GetAllStockMovementsQuery, PagedResponseO<StockMovementDto>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public GetAllStockMovementsQueryHandler(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseO<StockMovementDto>> Handle(GetAllStockMovementsQuery request, CancellationToken cancellationToken)
        {
            var query = _stockMovementRepository.AsQueryable();

            query = query
                .Include(m => m.StockLot)
                    .ThenInclude(sl => sl.Stock)
                        .ThenInclude(s => s.Product)
                .Include(m => m.Responsible);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(m =>
                    m.Id.ToString().Contains(searchTermLower) ||
                    m.Quantity.ToString().Contains(searchTermLower) ||
                    m.SourceDocumentType.ToLower().Contains(searchTermLower) ||
                    m.Type.ToString().ToLower().Contains(searchTermLower) ||
                    m.SourceDocumentId.ToString().Contains(searchTermLower) ||
                    (m.StockLot != null && m.StockLot.Stock.Product != null && m.StockLot.Stock.Product.Name.ToLower().Contains(searchTermLower)) ||
                    (m.Responsible != null && m.Responsible.Name.ToLower().Contains(searchTermLower))
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy?.ToLower())
            {
                case "productname":
                    query = request.SortOrder?.ToLower() == "desc" ?
                                query.OrderByDescending(m => m.StockLot.Stock.Product.Name) :
                                query.OrderBy(m => m.StockLot.Stock.Product.Name);
                    break;
                case "sourcedocumenttype":
                    query = request.SortOrder?.ToLower() == "desc" ?
                               query.OrderByDescending(m => m.SourceDocumentType) :
                               query.OrderBy(m => m.SourceDocumentType);
                    break;
                case "type":
                    query = request.SortOrder?.ToLower() == "desc" ?
                               query.OrderByDescending(m => m.Type) :
                               query.OrderBy(m => m.Type);
                    break;
                case "responsible":
                    query = request.SortOrder?.ToLower() == "desc" ?
                                query.OrderByDescending(m => m.Responsible.Name) :
                                query.OrderBy(m => m.Responsible.Name);
                    break;
                default:
                    query = request.SortOrder?.ToLower() == "desc" ?
                                query.OrderBy(m => m.CreatedOn) :
                                query.OrderByDescending(m => m.CreatedOn);
                    break;
            }

            var pagedMovements = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var movementDtos = _mapper.Map<List<StockMovementDto>>(pagedMovements);

            return new PagedResponseO<StockMovementDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                movementDtos
            );
        }
    }
}
