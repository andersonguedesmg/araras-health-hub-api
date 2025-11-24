using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockAdjustments
{
    public class ExportStockAdjustmentsQueryHandler : IRequestHandler<ExportStockAdjustmentsQuery, IEnumerable<StockAdjustmentDto>>
    {
        private readonly IStockAdjustmentRepository _repo;
        private readonly IMapper _mapper;

        public ExportStockAdjustmentsQueryHandler(IStockAdjustmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockAdjustmentDto>> Handle(ExportStockAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _repo.AsQueryable();

            query = query
                .AsNoTracking()
                .Include(a => a.Responsible)
                .Include(a => a.Account)
                .Include(a => a.AdjustmentItems)
                    .ThenInclude(ai => ai.Product);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(a =>
                    a.Id.ToString().Contains(searchTermLower) ||
                    a.Reason.ToLower().Contains(searchTermLower) ||
                    (a.Observation != null && a.Observation.ToLower().Contains(searchTermLower)) ||
                    a.AdjustmentDate.ToString().Contains(searchTermLower) ||
                    a.Type.ToString().ToLower().Contains(searchTermLower) ||
                    (a.Responsible != null && a.Responsible.Name.ToLower().Contains(searchTermLower)) ||
                    (a.Account != null && a.Account.UserName!.ToLower().Contains(searchTermLower)) ||
                    a.AdjustmentItems.Any(ai =>
                        (ai.Batch != null && ai.Batch.ToLower().Contains(searchTermLower)) ||
                        (ai.Brand != null && ai.Brand.ToLower().Contains(searchTermLower)) ||
                        ai.Product.Name.ToLower().Contains(searchTermLower)
                    )
                );
            }

            var adjustments = await query
                .OrderByDescending(a => a.AdjustmentDate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<StockAdjustmentDto>>(adjustments);
        }
    }
}
