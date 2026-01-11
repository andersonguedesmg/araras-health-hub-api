using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
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
            var query = _facilityRepository.GetQueryable();
            query = query
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name);

            var dropdownOptions = await query
                .Select(s => new FacilityNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<FacilityNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
