using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.ExportSuppliers
{
    public class ExportSuppliersQuery: IRequest<IEnumerable<SupplierDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
