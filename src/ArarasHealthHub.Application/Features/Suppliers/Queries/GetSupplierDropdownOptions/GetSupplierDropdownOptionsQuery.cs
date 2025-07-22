using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdownOptions
{
    public class GetSupplierDropdownOptionsQuery : IRequest<ApiResponse<List<SupplierNameDto>>> { }
}
