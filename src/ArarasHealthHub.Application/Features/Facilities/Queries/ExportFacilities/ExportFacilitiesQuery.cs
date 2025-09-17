using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.ExportFacilities
{
    public class ExportFacilitiesQuery : IRequest<IEnumerable<FacilityDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
