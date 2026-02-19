using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, ApiResponse<object>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public UpdateFacilityCommandHandler(
            IFacilityRepository facilityRepository,
            IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var existingFacility =
                await _facilityRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingFacility is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Facility)
                );
            }

            _mapper.Map(request, existingFacility);
            existingFacility.SetUpdatedOn();

            await _facilityRepository.UpdateAsync(existingFacility, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.Facility)
            );
        }
    }
}
