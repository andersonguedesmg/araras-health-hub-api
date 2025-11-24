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
            query = query
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

            var totalCount = await query.CountAsync(cancellationToken);

            IQueryable<Domain.Entities.StockAdjustment> orderedAdjustment;

            switch (request.OrderBy?.ToLower())
            {
                case "reason":
                    orderedAdjustment = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.Reason) :
                            query.OrderBy(a => a.Reason);
                    break;
                case "adjustmentdate":
                    orderedAdjustment = request.SortOrder?.ToLower() == "desc" ?
                           query.OrderByDescending(a => a.AdjustmentDate) :
                           query.OrderBy(a => a.AdjustmentDate);
                    break;
                case "responsible":
                    orderedAdjustment = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.Responsible!.Name) :
                            query.OrderBy(a => a.Responsible!.Name);
                    break;
                default:
                    orderedAdjustment = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.CreatedOn) :
                            query.OrderBy(a => a.CreatedOn);
                    break;
            }

            var pagedAdjustments = await orderedAdjustment
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
