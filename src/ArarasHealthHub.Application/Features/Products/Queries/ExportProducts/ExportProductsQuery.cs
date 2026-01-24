using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.ExportProducts
{
    public class ExportProductsQuery : IRequest<ApiResponse<FileResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
