using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeactivatePresentationForm
{
    public record DeactivatePresentationFormCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivatePresentationFormCommand WithId(int id)
            => this with { Id = id };
    }
}
