using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments
{
    public class GetAllStockAdjustmentsQueryHandler : IRequestHandler<GetAllStockAdjustmentsQuery, PagedResponse<StockAdjustmentDto>>
    {
        private readonly IStockAdjustmentRepository _repo;
        private readonly IMapper _mapper;

        public GetAllStockAdjustmentsQueryHandler(IStockAdjustmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockAdjustmentDto>> Handle(GetAllStockAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _repo.AsQueryable();
            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy.ToLower())
            {
                case "reason":
                    query = request.SortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(a => a.Reason) :
                        query.OrderBy(a => a.Reason);
                    break;
                case "productid":
                    query = request.SortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(a => a.ProductId) :
                        query.OrderBy(a => a.ProductId);
                    break;
                default:
                    query = request.SortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(a => a.Id) :
                        query.OrderBy(a => a.Id);
                    break;
            }

            var pagedAdjustments = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var adjustmentDtos = _mapper.Map<List<StockAdjustmentDto>>(pagedAdjustments);

            return new PagedResponse<StockAdjustmentDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                adjustmentDtos
            );
        }
    }
}
