using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById
{
    public record GetReceivingByIdQuery(int Id) : IRequest<ApiResponseO<ReceivingDto>>;
}
