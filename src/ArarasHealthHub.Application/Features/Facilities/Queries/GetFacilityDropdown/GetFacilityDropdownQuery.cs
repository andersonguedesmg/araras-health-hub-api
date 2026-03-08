using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdown
{
    public class GetFacilityDropdownQuery : PagedRequest, IRequest<PagedResult<DropdownItemResponse>> { }
}
