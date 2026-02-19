using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQuery : PagedRequest, IRequest<PagedResponse<DropdownItemDto>> { }
}
