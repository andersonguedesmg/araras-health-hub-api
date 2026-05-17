using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustmentById
{
    public class GetStockAdjustmentByIdQueryHandler : IRequestHandler<GetStockAdjustmentByIdQuery, Result<StockAdjustmentResponse>>
    {
        private readonly IStockAdjustmentRepository _repository;
        private readonly IMapper _mapper;

        public GetStockAdjustmentByIdQueryHandler(
            IStockAdjustmentRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<StockAdjustmentResponse>> Handle(
            GetStockAdjustmentByIdQuery request,
            CancellationToken cancellationToken)
        {
            var adjustment = await _repository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Responsible)
                .Include(x => x.Account)
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.MainCategory)
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.SubCategory)
                .Include(x => x.Items)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.PackagingType)
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (adjustment is null)
            {
                throw new NotFoundException(
                    "Ajuste de estoque não encontrado.");
            }

            var response =
                _mapper.Map<StockAdjustmentResponse>(
                    adjustment);

            return Result<StockAdjustmentResponse>.Success(
                response,
                "Ajuste de estoque encontrado com sucesso.");
        }
    }
}
