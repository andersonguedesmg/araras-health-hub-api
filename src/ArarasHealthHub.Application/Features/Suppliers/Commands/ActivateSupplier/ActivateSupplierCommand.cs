using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier
{
    public record ActivateSupplierCommand(int Id) : IRequest<Result>;
}
