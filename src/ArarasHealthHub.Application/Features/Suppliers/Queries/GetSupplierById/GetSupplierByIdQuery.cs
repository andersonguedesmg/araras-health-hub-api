using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery(int Id) : IRequest<Result<SupplierResponse>>;
}
