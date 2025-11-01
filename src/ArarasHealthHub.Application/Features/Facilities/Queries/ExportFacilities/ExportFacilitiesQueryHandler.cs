using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.ExportFacilities
{
    public class ExportFacilitiesQueryHandler : IRequestHandler<ExportFacilitiesQuery, IEnumerable<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public ExportFacilitiesQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacilityDto>> Handle(ExportFacilitiesQuery request, CancellationToken cancellationToken)
        {
            var facilitiesQuery = _facilityRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                facilitiesQuery = facilitiesQuery.Where(p =>
                    p.Id.ToString().Contains(searchTermLower) ||
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Address.Street.ToLower().Contains(searchTermLower) ||
                    p.Address.Number.ToLower().Contains(searchTermLower) ||
                    p.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    p.Address.City.ToLower().Contains(searchTermLower) ||
                    p.Address.State.ToLower().Contains(searchTermLower) ||
                    p.Address.Cep.ToLower().Contains(searchTermLower) ||
                    p.Contact.Email.ToLower().Contains(searchTermLower) ||
                    p.Contact.Phone.ToLower().Contains(searchTermLower) ||
                    p.IsActive.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredFacilities = await facilitiesQuery.ToListAsync(cancellationToken);
            var facilityDto = _mapper.Map<IEnumerable<FacilityDto>>(allFilteredFacilities);

            return facilityDto;
        }
    }
}
