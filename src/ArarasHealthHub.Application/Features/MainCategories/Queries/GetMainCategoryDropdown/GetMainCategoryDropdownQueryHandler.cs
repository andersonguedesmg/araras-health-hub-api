using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdown
{
    public class GetMainCategoryDropdownQueryHandler : IRequestHandler<GetMainCategoryDropdownQuery, PagedResponse<MainCategoryNameDto>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public GetMainCategoryDropdownQueryHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<PagedResponse<MainCategoryNameDto>> Handle(
            GetMainCategoryDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _mainCategoryRepository
                .GetQueryable()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(e => e.Name.ToLower().Contains(term));
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            queryable = queryable
                .OrderBy(e => e.Name)
                .ApplyPagination(request.PageNumber, request.PageSize);

            var items = await queryable
                .Select(e => new MainCategoryNameDto
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<MainCategoryNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
