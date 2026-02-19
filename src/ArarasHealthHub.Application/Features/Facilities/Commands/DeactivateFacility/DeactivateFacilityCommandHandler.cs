using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility
{
    public class DeactivateFacilityCommandHandler : IRequestHandler<DeactivateFacilityCommand, ApiResponse<object>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public DeactivateFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeactivateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository.GetByIdAsync(request.Id, cancellationToken);

            if (facility is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Facility)
                );
            }

            if (!facility.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyInactive(EntityNames.Facility)
                );
            }

            facility.Deactivate();
            await _facilityRepository.UpdateAsync(facility, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityDeactivated(EntityNames.Facility)
            );
        }
    }
}
