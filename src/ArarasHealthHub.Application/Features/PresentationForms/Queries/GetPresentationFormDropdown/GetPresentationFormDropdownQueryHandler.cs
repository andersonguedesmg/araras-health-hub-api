using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdown
{
    public class GetPresentationFormDropdownQueryHandler : IRequestHandler<GetPresentationFormDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public GetPresentationFormDropdownQueryHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetPresentationFormDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _presentationFormRepository
                .AsQueryable()
                .Where(p => p.IsActive);

            var term = request.SearchTerm?.Trim();

            if (!string.IsNullOrWhiteSpace(term))
            {
                var search = term.ToLower();

                queryable = queryable.Where(e =>
                    e.Name.ToLower().Contains(search)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var items = await queryable
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
