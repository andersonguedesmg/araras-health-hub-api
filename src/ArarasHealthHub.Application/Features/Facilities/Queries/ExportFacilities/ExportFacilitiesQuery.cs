using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.ExportFacilities
{
    public class ExportFacilitiesQuery : IRequest<ApiResponse<FileResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
