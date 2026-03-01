using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(
        int Id,
        string LegalName,
        string TradeName,
        string Cnpj,
        Address Address,
        Contact Contact
    ) : IRequest<Result>
    {
        public UpdateSupplierCommand WithId(int id)
            => this with { Id = id };
    }
}
