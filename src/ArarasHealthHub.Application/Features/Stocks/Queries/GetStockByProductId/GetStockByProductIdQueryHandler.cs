using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId
{
    public class GetStockByProductIdQueryHandler : IRequestHandler<GetStockByProductIdQuery, Result<StockResponse>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStockByProductIdQueryHandler(
            IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Result<StockResponse>> Handle(
            GetStockByProductIdQuery request,
            CancellationToken cancellationToken)
        {
            var stock = await _stockRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.StockCost)
                .Include(x => x.Product)
                    .ThenInclude(x => x.MainCategory)
                .Include(x => x.Product)
                    .ThenInclude(x => x.SubCategory)
                .Include(x => x.Product)
                    .ThenInclude(x => x.PackagingType)
                .FirstOrDefaultAsync(
                    x => x.ProductId == request.ProductId,
                    cancellationToken);

            if (stock is null)
                throw new NotFoundException("Estoque não foi encontrado.");

            var response = new StockResponse(
                stock.Id,
                stock.ProductId,

                new ProductResponse(
                    stock.Product.Id,
                    stock.Product.Name,
                    stock.Product.Description,

                    stock.Product.MainCategoryId,
                    stock.Product.MainCategory?.Name ?? string.Empty,

                    stock.Product.SubCategoryId,
                    stock.Product.SubCategory?.Name ?? string.Empty,

                    stock.Product.PackagingTypeId,
                    stock.Product.PackagingType?.Name ?? string.Empty,

                    stock.Product.CreatedOn,
                    stock.Product.UpdatedOn ?? stock.Product.CreatedOn,
                    stock.Product.IsActive),

                stock.CurrentQuantity,
                stock.ReservedQuantity,
                stock.AvailableQuantity,
                stock.MinQuantity,
                stock.StockCost?.AverageUnitCost ?? 0,
                stock.CreatedOn,
                stock.UpdatedOn);

            return Result<StockResponse>.Success(
                response,
                "Estoque encontrado com sucesso.");
        }
    }
}
