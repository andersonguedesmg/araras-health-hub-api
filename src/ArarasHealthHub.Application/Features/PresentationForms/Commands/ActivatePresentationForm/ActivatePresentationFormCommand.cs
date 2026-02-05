using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.ActivatePresentationForm
{
    public record ActivatePresentationFormCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivatePresentationFormCommand WithId(int id)
            => this with { Id = id };
    }
}
