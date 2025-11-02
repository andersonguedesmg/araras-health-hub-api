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
            var facilitiesQuery = _facilityRepository.GetQueryable();
            facilitiesQuery = facilitiesQuery.Include(f => f.Accounts);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                facilitiesQuery = facilitiesQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Address.Street.ToLower().Contains(searchTermLower) ||
                    p.Address.Number.ToLower().Contains(searchTermLower) ||
                    p.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    p.Address.City.ToLower().Contains(searchTermLower) ||
                    p.Address.State.ToLower().Contains(searchTermLower) ||
                    p.Address.Cep.ToLower().Contains(searchTermLower) ||
                    p.Contact.Email.ToLower().Contains(searchTermLower) ||
                    p.Contact.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await facilitiesQuery.CountAsync(cancellationToken);

            IQueryable<Facility> orderedFacilities;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedFacilities = request.SortOrder.ToLower() == "desc" ?
                            facilitiesQuery.OrderByDescending(s => s.Name) :
                            facilitiesQuery.OrderBy(s => s.Name);
                    break;
                default:
                    orderedFacilities = request.SortOrder.ToLower() == "desc" ?
                            facilitiesQuery.OrderByDescending(s => s.Id) :
                            facilitiesQuery.OrderBy(s => s.Id);
                    break;
            }

            var pagedFacilities = await orderedFacilities
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
