using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories
{
    public class GetAllSubCategoriesQuery : PagedRequest, IRequest<PagedResponse<SubCategoryDto>>
    {
        public string? SearchTerm { get; set; }
        public int MainCategoryId { get; set; }
    }
}
