using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeleteFacility
{
    public class DeleteFacilityCommandHandler : IRequestHandler<DeleteFacilityCommand, ApiResponse<object>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public DeleteFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var existingFacility =
                await _facilityRepository.GetByIdAsync(request.Id);

            if (existingFacility is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Unidade")
                );
            }

            await _facilityRepository.DeleteAsync(existingFacility);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Unidade")
            );
        }
    }
}
