using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.ExportSubCategories
{
    public class ExportSubCategoriesQueryHandler : IRequestHandler<ExportSubCategoriesQuery, ApiResponse<FileResponse>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public ExportSubCategoriesQueryHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportSubCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<SubCategory> query = _subCategoryRepository
                .AsQueryableWithMainCategory();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(x =>
                    x.Name.ToLower().Contains(term) ||
                    x.MainCategory!.Name.ToLower().Contains(term));
            }

            if (request.MainCategoryId > 0)
            {
                query = query.Where(x => x.MainCategoryId == request.MainCategoryId);
            }

            var subCategories = await query
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);

            if (!subCategories.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty(EntityNames.SubCategories)
                );
            }

            var csvBytes = SubCategoryCsvExporter.Export(subCategories);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"subcategorias_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
