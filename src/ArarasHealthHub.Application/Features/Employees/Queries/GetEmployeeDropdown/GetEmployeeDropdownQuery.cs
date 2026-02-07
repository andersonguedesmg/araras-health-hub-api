using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQuery : PagedRequest, IRequest<PagedResponse<DropdownItemDto>> { }
}
