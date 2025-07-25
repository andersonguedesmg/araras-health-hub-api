using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities
{
    public class GetAllFacilitiesQueryHandler : IRequestHandler<GetAllFacilitiesQuery, PagedResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetAllFacilitiesQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<FacilityDto>> Handle(GetAllFacilitiesQuery request, CancellationToken cancellationToken)
        {
            var query = _facilityRepository.AsQueryable();
            query = query.Include(f => f.Accounts);

            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy.ToLower())
            {
                case "name":
                    query = request.SortOrder.ToLower() == "desc" ?
                            query.OrderByDescending(s => s.Name) :
                            query.OrderBy(s => s.Name);
                    break;
                default:
                    query = request.SortOrder.ToLower() == "desc" ?
                            query.OrderByDescending(s => s.Id) :
                            query.OrderBy(s => s.Id);
                    break;
            }

            var pagedFacilities = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var facilityDtos = _mapper.Map<List<FacilityDto>>(pagedFacilities);

            return new PagedResponse<FacilityDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                facilityDtos
            );
        }
    }
}
