using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments
{
    public class GetAllStockAdjustmentsQueryHandler : IRequestHandler<GetAllStockAdjustmentsQuery, PagedResponseO<StockAdjustmentDto>>
    {
        private readonly IStockAdjustmentRepository _repo;
        private readonly IMapper _mapper;

        public GetAllStockAdjustmentsQueryHandler(IStockAdjustmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResponseO<StockAdjustmentDto>> Handle(GetAllStockAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _repo.AsQueryable()
                .AsNoTracking()
                .Include(a => a.Responsible)
                .Include(a => a.Account)
                .Include(a => a.Items)
                    .ThenInclude(ai => ai.Product)
                        .ThenInclude(p => p.MainCategory)
                .Include(a => a.Items)
                    .ThenInclude(ai => ai.Product)
                        .ThenInclude(p => p.PackagingType)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();
                query = query.Where(a =>
                    a.Reason.ToLower().Contains(searchTerm) ||
                    a.Responsible!.Name.ToLower().Contains(searchTerm) ||
                    a.Items.Any(ai => ai.Product.Name.ToLower().Contains(searchTerm))
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var pagedAdjustments = await query
                .OrderByDescending(a => a.AdjustmentDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResponseO<StockAdjustmentDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                _mapper.Map<List<StockAdjustmentDto>>(pagedAdjustments)
            );
        }
    }
}
