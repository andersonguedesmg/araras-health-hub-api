using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm
{
    public record CreatePresentationFormCommand(
        string Name
    ) : IRequest<ApiResponse<int>>;
}
