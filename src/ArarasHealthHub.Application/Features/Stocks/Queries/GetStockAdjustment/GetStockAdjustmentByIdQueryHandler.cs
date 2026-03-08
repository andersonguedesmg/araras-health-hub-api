using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustment
{
    public class GetStockAdjustmentByIdQueryHandler : IRequestHandler<GetStockAdjustmentByIdQuery, ApiResponseO<StockAdjustmentDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStockAdjustmentByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<StockAdjustmentDto>> Handle(GetStockAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            var adjustment = await _dbContext.StockAdjustments
                .Include(a => a.Responsible)
                .Include(a => a.Account)
                .Include(a => a.AdjustmentItems)
                    .ThenInclude(ai => ai.Product)
                        .ThenInclude(p => p.MainCategory)
                .Include(a => a.AdjustmentItems)
                    .ThenInclude(ai => ai.Product)
                        .ThenInclude(p => p.SubCategory)
                .Include(a => a.AdjustmentItems)
                    .ThenInclude(ai => ai.Product)
                        .ThenInclude(p => p.PackagingType)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (adjustment == null)
            {
                return new ApiResponseO<StockAdjustmentDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Ajuste de Estoque", request.Id), false);
            }

            var adjustmentDto = _mapper.Map<StockAdjustmentDto>(adjustment);

            return new ApiResponseO<StockAdjustmentDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Ajuste de Estoque"), adjustmentDto);
        }
    }
}
