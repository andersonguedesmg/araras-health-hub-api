using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQuery : PagedRequest, IRequest<PagedResult<DropdownItemResponse>> { }
}
