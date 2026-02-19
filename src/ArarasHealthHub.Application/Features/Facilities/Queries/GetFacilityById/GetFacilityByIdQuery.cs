using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById
{
    public record GetFacilityByIdQuery(int Id) : IRequest<ApiResponse<FacilityDto>>
    {
        public GetFacilityByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
