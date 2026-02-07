using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier
{
    public record DeactivateSupplierCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateSupplierCommand WithId(int id)
            => this with { Id = id };
    }
}
