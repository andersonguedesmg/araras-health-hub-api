using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility
{
    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, ApiResponse<int>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public CreateFacilityCommandHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(
            CreateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var existingFacility =
                await _facilityRepository.GetByNameAsync(request.Name, cancellationToken);

            if (existingFacility is not null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.Facility)
                );
            }

            var facility = _mapper.Map<Facility>(request);

            await _facilityRepository.AddAsync(facility, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.Facility),
                facility.Id
            );
        }
    }
}
