using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Shared.Requests;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQuery : PagedRequest, IRequest<PagedResponseO<ReceivingDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
