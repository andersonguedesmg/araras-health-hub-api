using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown
{
    public class GetSubCategoryDropdownQuery : PagedRequest, IRequest<PagedResult<DropdownItemResponse>>
    {
        public int MainCategoryId { get; set; }
    }
}
