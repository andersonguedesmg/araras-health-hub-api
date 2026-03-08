using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById
{
    public record GetFacilityByIdQuery(int Id) : IRequest<Result<FacilityResponse>>;
}
