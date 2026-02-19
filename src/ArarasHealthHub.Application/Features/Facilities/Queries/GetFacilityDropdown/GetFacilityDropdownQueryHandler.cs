using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdown
{
    public class GetFacilityDropdownQueryHandler : IRequestHandler<GetFacilityDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetFacilityDropdownQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetFacilityDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _facilityRepository
                .AsQueryable()
                .Where(e => e.IsActive);

            var term = request.SearchTerm?.Trim();

            if (!string.IsNullOrWhiteSpace(term))
            {
                var search = term.ToLower();

                queryable = queryable.Where(f =>
                    f.Name.ToLower().Contains(search)
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
