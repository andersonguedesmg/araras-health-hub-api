using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeleteFacility
{
    public class DeleteFacilityCommandHandler : IRequestHandler<DeleteFacilityCommand, ApiResponse<bool>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public DeleteFacilityCommandHandler(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByIdAsync(request.Id);

            if (existingFacility == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, false);
            }

            await _facilityRepository.DeleteAsync(existingFacility);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.MsgFacilityDeletedSuccessfully, true);
        }
    }
}
