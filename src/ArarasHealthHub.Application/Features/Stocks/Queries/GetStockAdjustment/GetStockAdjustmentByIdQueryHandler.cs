using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustment
{
    public class GetStockAdjustmentByIdQueryHandler : IRequestHandler<GetStockAdjustmentByIdQuery, ApiResponse<StockAdjustmentDto>>
    {
        private readonly IStockAdjustmentRepository _repo;

        public GetStockAdjustmentByIdQueryHandler(IStockAdjustmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<StockAdjustmentDto>> Handle(GetStockAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            var adjustment = await _repo.GetByIdAsync(request.Id);

            if (adjustment == null)
            {
                return new ApiResponse<StockAdjustmentDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Ajuste"), null);
            }

            var adjustmentDto = new StockAdjustmentDto
            {
                Id = adjustment.Id,
                ProductId = adjustment.ProductId,
                Quantity = adjustment.Quantity,
                Reason = adjustment.Reason,
                ResponsibleId = adjustment.ResponsibleId,
                CreatedOn = adjustment.CreatedOn
            };

            return new ApiResponse<StockAdjustmentDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Ajuste"), adjustmentDto);
        }
    }
}
