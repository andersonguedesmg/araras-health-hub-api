using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdown
{
    public class GetProductDropdownQuery : PagedRequest, IRequest<PagedResponse<DropdownItemDto>> { }
}
