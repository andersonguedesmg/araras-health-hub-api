using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public record UpdateSupplierCommand(
        int Id,
        string Name,
        string Cnpj,
        string Address,
        string Number,
        string Neighborhood,
        string City,
        string State,
        string Cep,
        string Email,
        string Phone
    ) : IRequest<ApiResponse<bool>>;
}
