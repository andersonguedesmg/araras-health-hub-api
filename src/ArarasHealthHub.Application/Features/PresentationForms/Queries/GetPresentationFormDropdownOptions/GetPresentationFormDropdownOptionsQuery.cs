using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdownOptions
{
    public record GetPresentationFormDropdownOptionsQuery() : IRequest<ApiResponse<List<PresentationFormNameDto>>>;
}
