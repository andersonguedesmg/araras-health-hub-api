using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.ExportMainCategories
{
    public class ExportMainCategoriesQueryHandler : IRequestHandler<ExportMainCategoriesQuery, ApiResponse<FileResponse>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ExportMainCategoriesQueryHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportMainCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _mainCategoryRepository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(e =>
                    e.Name.ToLower().Contains(term)
                );
            }

            var mainCategories = await query
                .OrderBy(e => e.Name)
                .ToListAsync(cancellationToken);

            if (!mainCategories.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty(EntityNames.MainCategory)
                );
            }

            var csvBytes = MainCategoryCsvExporter.Export(mainCategories);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"categorias_principais_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
