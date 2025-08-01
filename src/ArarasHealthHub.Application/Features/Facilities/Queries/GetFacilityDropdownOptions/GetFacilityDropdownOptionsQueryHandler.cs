using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdownOptions
{
    public class GetFacilityDropdownOptionsQueryHandler : IRequestHandler<GetFacilityDropdownOptionsQuery, ApiResponse<List<FacilityNameDto>>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetFacilityDropdownOptionsQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<FacilityNameDto>>> Handle(GetFacilityDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _facilityRepository.AsQueryable();

            query = query.Where(s => s.IsActive);

            query = query.OrderBy(s => s.Name);

            var activeFacilitys = await query.ToListAsync(cancellationToken);

            var dropdownOptions = _mapper.Map<List<FacilityNameDto>>(activeFacilitys);

            return new ApiResponse<List<FacilityNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
