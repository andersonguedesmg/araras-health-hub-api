using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility
{
    public sealed record GetAccountsByFacilityQuery(
        int FacilityId
    ) : IRequest<ApiResponse<List<GetAccountsByFacilityResponse>>>;
}
