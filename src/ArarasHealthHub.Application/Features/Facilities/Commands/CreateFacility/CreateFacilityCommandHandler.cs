using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility
{
    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, ApiResponse<int>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public CreateFacilityCommandHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreateFacilityCommand request, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByNameAsync(request.Name);
            if (existingFacility != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.MsgFacilityAlreadyExists, 0);
            }

            var facility = _mapper.Map<Facility>(request);

            await _facilityRepository.AddAsync(facility);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.MsgFacilityCreatedSuccessfully, facility.Id);
        }
    }
}
