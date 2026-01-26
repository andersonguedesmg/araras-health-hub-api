using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdown
{
    public class GetPresentationFormDropdownQuery : PagedRequest, IRequest<PagedResponse<PresentationFormNameDto>> { }
}
