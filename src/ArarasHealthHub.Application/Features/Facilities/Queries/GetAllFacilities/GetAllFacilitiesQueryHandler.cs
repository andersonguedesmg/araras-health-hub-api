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
            var allFacilities = await _facilityRepository.GetAllAsync();

            var totalCount = allFacilities.Count();

            IOrderedEnumerable<Facility> orderedFacilities;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedFacilities = request.SortOrder.ToLower() == "desc" ?
                        allFacilities.OrderByDescending(s => s.Name) :
                        allFacilities.OrderBy(s => s.Name);
                    break;
                default:
                    orderedFacilities = request.SortOrder.ToLower() == "desc" ?
                        allFacilities.OrderByDescending(s => s.Id) :
                        allFacilities.OrderBy(s => s.Id);
                    break;
            }

            var pagedFacilities = orderedFacilities
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var FacilityDtos = _mapper.Map<List<FacilityDto>>(pagedFacilities);

            return new PagedResponse<FacilityDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                FacilityDtos
            );
        }
    }
}
