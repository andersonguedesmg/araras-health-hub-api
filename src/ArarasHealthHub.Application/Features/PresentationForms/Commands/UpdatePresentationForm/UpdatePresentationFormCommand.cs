using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm
{
    public record UpdatePresentationFormCommand(
        int Id,
        string Name
    ) : IRequest<ApiResponse<object>>
    {
        public UpdatePresentationFormCommand WithId(int id)
            => this with { Id = id };
    }
}
