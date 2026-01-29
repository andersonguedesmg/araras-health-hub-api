using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdown
{
    public class GetMainCategoryDropdownQuery : PagedRequest, IRequest<PagedResponse<DropdownItemDto>> { }
}
