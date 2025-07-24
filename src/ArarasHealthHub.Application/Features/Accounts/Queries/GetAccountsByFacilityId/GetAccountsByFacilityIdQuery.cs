using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId
{
    public record GetAccountsByFacilityIdQuery : IRequest<ApiResponse<List<AccountDetailsDto>>>
    {
        public int FacilityId { get; init; }
    }
}
