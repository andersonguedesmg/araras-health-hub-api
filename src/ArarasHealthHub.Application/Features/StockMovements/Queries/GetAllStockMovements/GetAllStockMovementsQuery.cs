using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Shared.Requests;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements
{
    public class GetAllStockMovementsQuery : PagedRequest, IRequest<PagedResponseO<StockMovementDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
