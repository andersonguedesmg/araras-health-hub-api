using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms
{
    public class GetAllPresentationFormsQuery : PagedRequest, IRequest<PagedResponse<PresentationFormDto>> { }
}
