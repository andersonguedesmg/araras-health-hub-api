using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities
{
    public class GetAllFacilitiesQuery : PagedRequest, IRequest<PagedResponse<FacilityDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
