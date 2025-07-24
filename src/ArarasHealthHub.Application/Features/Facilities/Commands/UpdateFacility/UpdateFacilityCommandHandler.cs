using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, ApiResponse<bool>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public UpdateFacilityCommandHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateFacilityCommand request, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByIdAsync(request.Id);

            if (existingFacility == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, false);
            }

            _mapper.Map(request, existingFacility);

            existingFacility.SetUpdatedOn();

            await _facilityRepository.UpdateAsync(existingFacility);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.MsgFacilityUpdatedSuccessfully, true);
        }
    }
}
