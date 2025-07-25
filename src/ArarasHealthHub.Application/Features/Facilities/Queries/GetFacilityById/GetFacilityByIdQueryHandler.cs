using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById
{
    public class GetFacilityByIdQueryHandler : IRequestHandler<GetFacilityByIdQuery, ApiResponse<FacilityDto>>
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IMapper _mapper;

        public GetFacilityByIdQueryHandler(IFacilityRepository facilityRepository, IMapper mapper)
        {
            _facilityRepository = facilityRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FacilityDto>> Handle(GetFacilityByIdQuery request, CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository.GetByIdWithAccountsAsync(request.Id);

            if (facility == null)
            {
                return new ApiResponse<FacilityDto>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, null!);
            }

            var facilityDto = _mapper.Map<FacilityDto>(facility);

            return new ApiResponse<FacilityDto>(StatusCodes.Status200OK, ApiMessages.MsgFacilityFoundSuccessfully, facilityDto);
        }
    }
}
