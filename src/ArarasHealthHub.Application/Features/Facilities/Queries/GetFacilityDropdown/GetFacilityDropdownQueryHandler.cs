using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdown
{
    public class GetFacilityDropdownQueryHandler : IRequestHandler<GetFacilityDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetFacilityDropdownQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetFacilityDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _facilityRepository
                .AsQueryable()
                .AsNoTracking();

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(f =>
                    EF.Functions.Like(f.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(f => f.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(f => new DropdownItemResponse(
                    f.Id,
                    f.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Unidades listadas para seleção.");
        }
    }
}
