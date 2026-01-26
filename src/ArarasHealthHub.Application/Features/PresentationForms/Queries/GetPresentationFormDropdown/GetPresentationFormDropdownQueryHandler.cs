using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdown
{
    public class GetPresentationFormDropdownQueryHandler : IRequestHandler<GetPresentationFormDropdownQuery, PagedResponse<PresentationFormNameDto>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public GetPresentationFormDropdownQueryHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<PagedResponse<PresentationFormNameDto>> Handle(
            GetPresentationFormDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _presentationFormRepository
                .GetQueryable()
                .Where(p => p.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(p => p.Name.ToLower().Contains(term));
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            queryable = queryable
                .OrderBy(p => p.Name)
                .ApplyPagination(request.PageNumber, request.PageSize);

            var items = await queryable
                .Select(p => new PresentationFormNameDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<PresentationFormNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
