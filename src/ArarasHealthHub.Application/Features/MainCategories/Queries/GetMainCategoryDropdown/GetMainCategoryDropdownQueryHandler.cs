using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdown
{
    public class GetMainCategoryDropdownQueryHandler : IRequestHandler<GetMainCategoryDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public GetMainCategoryDropdownQueryHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetMainCategoryDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _mainCategoryRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(mc => mc.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(mc =>
                    EF.Functions.Like(mc.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(mc => mc.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(mc => new DropdownItemResponse(
                    mc.Id,
                    mc.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Categorias principais listadas para seleção.");
        }
    }
}
