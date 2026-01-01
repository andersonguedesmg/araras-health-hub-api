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
                facilitiesQuery = facilitiesQuery.Where(f =>
                    f.Name.ToLower().Contains(searchTermLower) ||
                    f.Cnes.ToLower().Contains(searchTermLower) ||
                    f.Address.Street.ToLower().Contains(searchTermLower) ||
                    f.Address.Number.ToLower().Contains(searchTermLower) ||
                    f.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    f.Address.City.ToLower().Contains(searchTermLower) ||
                    f.Address.State.ToLower().Contains(searchTermLower) ||
                    f.Address.Cep.ToLower().Contains(searchTermLower) ||
                    f.Contact.Email.ToLower().Contains(searchTermLower) ||
                    f.Contact.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredFacilities = await facilitiesQuery.OrderBy(f => f.Name).ToListAsync(cancellationToken);
            var facilityDto = _mapper.Map<IEnumerable<FacilityDto>>(allFilteredFacilities);

            return facilityDto;
        }
    }
}
