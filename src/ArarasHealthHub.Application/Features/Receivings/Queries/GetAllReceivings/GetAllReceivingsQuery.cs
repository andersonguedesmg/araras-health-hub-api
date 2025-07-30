using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQuery : PagedRequest, IRequest<PagedResponse<ReceivingDto>> { }
}
