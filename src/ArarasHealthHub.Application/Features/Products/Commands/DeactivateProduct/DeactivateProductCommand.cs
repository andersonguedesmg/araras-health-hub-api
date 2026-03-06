using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.DeactivateProduct
{
    public sealed record DeactivateProductCommand(int Id) : IRequest<Result>;
}
