using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.ExportPresentationForms
{
    public class ExportPresentationFormsQuery : IRequest<ApiResponse<FileResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
