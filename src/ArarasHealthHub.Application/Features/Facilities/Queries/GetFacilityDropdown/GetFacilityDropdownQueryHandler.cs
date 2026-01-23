using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdown
{
    public class GetFacilityDropdownQueryHandler : IRequestHandler<GetFacilityDropdownQuery, PagedResponse<FacilityNameDto>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetFacilityDropdownQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<PagedResponse<FacilityNameDto>> Handle(
            GetFacilityDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _facilityRepository
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
                .Select(e => new FacilityNameDto
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<FacilityNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
