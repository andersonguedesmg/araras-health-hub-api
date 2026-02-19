using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown
{
    public class GetSubCategoryDropdownQueryHandler : IRequestHandler<GetSubCategoryDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public GetSubCategoryDropdownQueryHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetSubCategoryDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _subCategoryRepository
                .AsQueryableWithMainCategory()
                .Where(x => x.IsActive);

            if (request.MainCategoryId > 0)
            {
                query = query.Where(x => x.MainCategoryId == request.MainCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(x =>
                    x.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(x => x.Name)
                .ApplyPagination(request.PageNumber, request.PageSize)
                .Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Label = x.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<DropdownItemDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
