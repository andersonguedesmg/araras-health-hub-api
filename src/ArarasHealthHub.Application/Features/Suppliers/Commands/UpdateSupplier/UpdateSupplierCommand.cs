using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(
        int Id,
        string LegalName,
        string TradeName,
        string Cnpj,
        AddressDto Address,
        ContactDto Contact
    ) : IRequest<ApiResponse<bool>>;
}
