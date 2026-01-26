using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormById
{
    public record GetPresentationFormByIdQuery(int Id) : IRequest<ApiResponse<PresentationFormDto>>
    {
        public GetPresentationFormByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
