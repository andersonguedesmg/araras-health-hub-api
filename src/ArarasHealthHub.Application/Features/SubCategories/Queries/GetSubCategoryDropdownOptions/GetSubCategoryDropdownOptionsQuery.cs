using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdownOptions
{
    public class GetSubCategoryDropdownOptionsQuery : IRequest<ApiResponse<List<SubCategoryNameDto>>>
    {
        public int MainCategoryId { get; set; }
    }
}
