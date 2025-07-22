using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdownOptions
{
    /// <summary>
    /// Query para obter opções simplificadas de produtos (ID e Nome) para uso em dropdowns.
    /// </summary>
    public record GetProductDropdownOptionsQuery() : IRequest<ApiResponse<List<ProductNameDto>>>;
}
