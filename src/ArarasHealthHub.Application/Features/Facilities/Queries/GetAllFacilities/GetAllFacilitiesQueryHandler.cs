using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities
{
    public class GetAllFacilitiesQueryHandler : IRequestHandler<GetAllFacilitiesQuery, PagedResult<FacilityListItemResponse>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetAllFacilitiesQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<PagedResult<FacilityListItemResponse>> Handle(
            GetAllFacilitiesQuery request,
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

                query = query.Where(s =>
                    EF.Functions.Like(s.Name, $"%{term}%") ||
                    EF.Functions.Like(s.Cnes, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Name)
                    : query.OrderBy(x => x.Name),

                "cnes" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Cnes)
                    : query.OrderBy(x => x.Cnes),

                _ => query.OrderBy(x => x.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(s => new FacilityListItemResponse(
                    s.Id,
                    s.Name,
                    s.Cnes,
                    new AddressResponse(
                        s.Address.Street,
                        s.Address.Number,
                        s.Address.Complement,
                        s.Address.Neighborhood,
                        s.Address.City,
                        s.Address.State,
                        s.Address.Cep
                    ),
                    new ContactResponse(
                        s.Contact.Email,
                        s.Contact.Phone
                    ),
                    s.IsActive
                ))
                .ToListAsync(cancellationToken);

            return PagedResult<FacilityListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Unidades listadas com sucesso.");
        }
    }
}
