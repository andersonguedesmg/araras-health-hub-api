using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.ExportProducts
{
    public class ExportProductsQueryHandler : IRequestHandler<ExportProductsQuery, ApiResponse<FileResponse>>
    {
        private readonly IProductRepository _productRepository;

        public ExportProductsQueryHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportProductsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _productRepository.AsQueryableWithIncludes();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Description.ToLower().Contains(term) ||
                    p.MainCategory!.Name.ToLower().Contains(term) ||
                    p.SubCategory!.Name.ToLower().Contains(term) ||
                    p.PresentationForm!.Name.ToLower().Contains(term)
                );
            }

            var products = await query
                .OrderBy(e => e.Name)
                .ToListAsync(cancellationToken);

            if (!products.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty(EntityNames.Product)
                );
            }

            var csvBytes = ProductCsvExporter.Export(products);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"produtos_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
