using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.ActivateFacility
{
    public class ActivateFacilityCommandHandler : IRequestHandler<ActivateFacilityCommand, ApiResponse<object>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public ActivateFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateFacilityCommand request,
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

            if (facility.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.Facility)
                );
            }

            facility.Activate();
            await _facilityRepository.UpdateAsync(facility, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.Facility)
            );
        }
    }
}
