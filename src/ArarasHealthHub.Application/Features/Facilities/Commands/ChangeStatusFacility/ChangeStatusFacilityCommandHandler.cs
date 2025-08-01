using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.ChangeStatusFacility
{
    public class ChangeStatusFacilityCommandHandler : IRequestHandler<ChangeStatusFacilityCommand, ApiResponse<bool>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public ChangeStatusFacilityCommandHandler(IFacilityRepository FacilityRepository)
        {
            _facilityRepository = FacilityRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusFacilityCommand command, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByIdAsync(command.Id);

            if (existingFacility == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Unidade"), false);
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

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Unidade") : ApiMessages.DeactivatedSuccessfully("Unidade");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
