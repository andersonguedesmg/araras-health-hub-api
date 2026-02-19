using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.ExportSubCategories
{
    public class ExportSubCategoriesQuery : IRequest<ApiResponse<FileResponse>>
    {
        public string? SearchTerm { get; set; }
        public int MainCategoryId { get; set; }
    }
}
