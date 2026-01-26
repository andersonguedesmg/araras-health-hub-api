using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown
{
    public class GetSubCategoryDropdownQuery : PagedRequest, IRequest<PagedResponse<MainCategoryNameDto>>
    {
        public int MainCategoryId { get; set; }
    }
}
