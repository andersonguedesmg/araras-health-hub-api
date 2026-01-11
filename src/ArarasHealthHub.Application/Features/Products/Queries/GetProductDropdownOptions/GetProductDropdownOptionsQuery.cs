using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdownOptions
{
    public record GetProductDropdownOptionsQuery() : IRequest<ApiResponse<List<ProductNameDto>>>;
}
