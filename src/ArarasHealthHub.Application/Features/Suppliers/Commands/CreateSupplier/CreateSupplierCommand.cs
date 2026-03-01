using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public record CreateSupplierCommand(
        string LegalName,
        string TradeName,
        string Cnpj,
        Address Address,
        Contact Contact
    ) : IRequest<Result<int>>;
}
