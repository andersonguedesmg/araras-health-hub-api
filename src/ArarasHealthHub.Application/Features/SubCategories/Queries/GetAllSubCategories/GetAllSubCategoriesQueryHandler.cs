using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories
{
    public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, PagedResult<SubCategoryListItemResponse>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public GetAllSubCategoriesQueryHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<PagedResult<SubCategoryListItemResponse>> Handle(
            GetAllSubCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _subCategoryRepository
                .AsQueryableWithMainCategory()
                .AsNoTracking();

            if (request.MainCategoryId > 0)
            {
                query = query.Where(sc =>
                    sc.MainCategoryId == request.MainCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(sc =>
                    EF.Functions.Like(sc.Name, $"%{term}%") ||
                    EF.Functions.Like(sc.MainCategory!.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(sc => sc.Name)
                    : query.OrderBy(sc => sc.Name),

                "maincategory" => request.SortOrder == "desc"
                    ? query.OrderByDescending(sc => sc.MainCategory!.Name)
                    : query.OrderBy(sc => sc.MainCategory!.Name),

                _ => query.OrderBy(sc => sc.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(sc => new SubCategoryListItemResponse(
                    sc.Id,
                    sc.Name,
                    sc.MainCategoryId,
                    sc.MainCategory!.Name,
                    sc.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<SubCategoryListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Subcategorias listadas com sucesso.");
        }
    }
}
