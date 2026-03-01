using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdown
{
    public class GetPresentationFormDropdownQueryHandler : IRequestHandler<GetPresentationFormDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public GetPresentationFormDropdownQueryHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetPresentationFormDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _presentationFormRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(pf =>
                    EF.Functions.Like(pf.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(pf => pf.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(pf => new DropdownItemResponse(
                    pf.Id,
                    pf.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Formas de apresentação listadas para seleção.");
        }
    }
}
