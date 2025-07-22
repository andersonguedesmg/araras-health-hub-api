using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public record DeleteSupplierCommand(int Id) : IRequest<ApiResponse<bool>>;
}
