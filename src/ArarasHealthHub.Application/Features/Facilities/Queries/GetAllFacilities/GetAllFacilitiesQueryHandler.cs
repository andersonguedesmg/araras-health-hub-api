using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Pagination;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities
{
    public class GetAllFacilitiesQueryHandler : IRequestHandler<GetAllFacilitiesQuery, PagedResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilitiesQueryHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<FacilityDto>> Handle(
            GetAllFacilitiesQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _facilityRepository.AsQueryable();
            queryable = queryable.Include(f => f.Accounts);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                queryable = queryable.Where(f =>
                    f.Name.ToLower().Contains(term) ||
                    f.Cnes.ToLower().Contains(term) ||
                    f.Address.Street.ToLower().Contains(term) ||
                    f.Address.Number.ToLower().Contains(term) ||
                    f.Address.Neighborhood.ToLower().Contains(term) ||
                    f.Address.City.ToLower().Contains(term) ||
                    f.Address.State.ToLower().Contains(term) ||
                    f.Address.Cep.ToLower().Contains(term) ||
                    f.Contact.Email.ToLower().Contains(term) ||
                    f.Contact.Phone.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<Facility, object>>>
            {
                ["name"] = f => f.Name,
                ["cnes"] = f => f.Cnes,
            };

            queryable = queryable.ApplyOrdering(
                request.OrderBy?.ToLower(),
                request.SortOrder?.ToLower() ?? "asc",
                orderingColumns
            );

            queryable = queryable.ApplyPagination(
                request.PageNumber,
                request.PageSize
            );

            var items = await queryable.ToListAsync(cancellationToken);

            var dtoList = _mapper.Map<IReadOnlyList<FacilityDto>>(items);

            return PagedResponse<FacilityDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
