using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown
{
    public class GetSubCategoryDropdownQueryHandler : IRequestHandler<GetSubCategoryDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public GetSubCategoryDropdownQueryHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetSubCategoryDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _subCategoryRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.MainCategoryId == request.MainCategoryId);

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(sc => sc.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(sc => new DropdownItemResponse(
                    sc.Id,
                    sc.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Subcategorias listadas para seleção.");
        }
    }
}
