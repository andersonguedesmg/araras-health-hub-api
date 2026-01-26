using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeletePresentationForm
{
    public record DeletePresentationFormCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeletePresentationFormCommand WithId(int id)
            => this with { Id = id };
    }
}
