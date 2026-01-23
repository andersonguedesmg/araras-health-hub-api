using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.ChangeStatusFacility
{
    public class ChangeStatusFacilityCommandHandler : IRequestHandler<ChangeStatusFacilityCommand, ApiResponse<object>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public ChangeStatusFacilityCommandHandler(
            IFacilityRepository FacilityRepository)
        {
            _facilityRepository = FacilityRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeStatusFacilityCommand command,
            CancellationToken cancellationToken)
        {
            var existingFacility =
                await _facilityRepository.GetByIdAsync(command.Id);

            if (existingFacility is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Unidade")
                );
            }

            if (command.IsActive)
            {
                existingFacility.Activate();
            }
            else
            {
                existingFacility.Deactivate();
            }

            await _facilityRepository.UpdateAsync(existingFacility);

            var message = command.IsActive
                ? ApiMessages.ActivatedSuccessfully("Unidade")
                : ApiMessages.DeactivatedSuccessfully("Unidade");

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                message
            );
        }
    }
}
