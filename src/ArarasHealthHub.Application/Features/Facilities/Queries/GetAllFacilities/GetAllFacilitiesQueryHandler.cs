using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Responses;
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
                var searchTerm = request.SearchTerm.Trim().ToLower();

                facilitiesQuery = facilitiesQuery.Where(f =>
                    f.Name.ToLower().Contains(searchTerm) ||
                    f.Cnes.ToLower().Contains(searchTerm) ||
                    f.Address.Street.ToLower().Contains(searchTerm) ||
                    f.Address.Number.ToLower().Contains(searchTerm) ||
                    f.Address.Neighborhood.ToLower().Contains(searchTerm) ||
                    f.Address.City.ToLower().Contains(searchTerm) ||
                    f.Address.State.ToLower().Contains(searchTerm) ||
                    f.Address.Cep.ToLower().Contains(searchTerm) ||
                    f.Contact.Email.ToLower().Contains(searchTerm) ||
                    f.Contact.Phone.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await facilitiesQuery.CountAsync(cancellationToken);

            IOrderedQueryable<Facility> orderedFacilities;
            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedFacilities = request.SortOrder?.ToLower() == "desc" ?
                            facilitiesQuery.OrderByDescending(s => s.Name) :
                            facilitiesQuery.OrderBy(s => s.Name);
                    break;
                case "cnes":
                    orderedFacilities = request.SortOrder?.ToLower() == "desc" ?
                            facilitiesQuery.OrderByDescending(s => s.Cnes) :
                            facilitiesQuery.OrderBy(s => s.Cnes);
                    break;
                default:
                    orderedFacilities = facilitiesQuery.OrderBy(e => e.Name);
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
