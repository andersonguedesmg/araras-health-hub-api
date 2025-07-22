using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public record GetAllSuppliersQuery() : IRequest<ApiResponse<List<SupplierDto>>>;
}
