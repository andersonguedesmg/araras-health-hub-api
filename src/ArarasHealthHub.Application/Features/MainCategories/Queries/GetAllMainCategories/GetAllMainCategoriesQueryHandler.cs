using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories
{
    public class GetAllMainCategoriesQueryHandler : IRequestHandler<GetAllMainCategoriesQuery, PagedResult<MainCategoryListItemResponse>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public GetAllMainCategoriesQueryHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<PagedResult<MainCategoryListItemResponse>> Handle(
            GetAllMainCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _mainCategoryRepository
                .AsQueryable()
                .AsNoTracking();

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(mc =>
                    EF.Functions.Like(mc.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(mc => mc.Name)
                    : query.OrderBy(mc => mc.Name),

                _ => query.OrderBy(mc => mc.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(mc => new MainCategoryListItemResponse(
                    mc.Id,
                    mc.Name,
                    mc.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<MainCategoryListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Categorias principais listadas com sucesso.");
        }
    }
}
