using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand(
        string Name,
        string Cnpj,
        AddressDto Address,
        ContactDto Contact
    ) : IRequest<ApiResponse<int>>;
}
