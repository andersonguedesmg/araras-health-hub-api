using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustment
{
    public class GetStockAdjustmentByIdQueryHandler : IRequestHandler<GetStockAdjustmentByIdQuery, ApiResponse<StockAdjustmentDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStockAdjustmentByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockAdjustmentDto>> Handle(GetStockAdjustmentByIdQuery request, CancellationToken cancellationToken)
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
                        .ThenInclude(p => p.PresentationForm)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (adjustment == null)
            {
                return new ApiResponse<StockAdjustmentDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Ajuste de Estoque", request.Id), null);
            }

            var adjustmentDto = _mapper.Map<StockAdjustmentDto>(adjustment);

            return new ApiResponse<StockAdjustmentDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Ajuste de Estoque"), adjustmentDto);
        }
    }
}
