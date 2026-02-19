using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown
{
    public class GetSubCategoryDropdownQuery : PagedRequest, IRequest<PagedResponse<DropdownItemDto>>
    {
        public int MainCategoryId { get; set; }
    }
}
