using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById
{
    public record GetSupplierByIdQuery(int Id) : IRequest<ApiResponse<SupplierDto>>
    {
        public GetSupplierByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
