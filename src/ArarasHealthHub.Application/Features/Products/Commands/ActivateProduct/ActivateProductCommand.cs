using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.ActivateProduct
{
    public record ActivateProductCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateProductCommand WithId(int id)
            => this with { Id = id };
    }
}
