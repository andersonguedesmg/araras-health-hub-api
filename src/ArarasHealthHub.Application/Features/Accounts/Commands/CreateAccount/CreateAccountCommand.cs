using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount
{
    public sealed record CreateAccountCommand(
        string UserName,
        string Password,
        int FacilityId,
        AccountScopeEnum Scope,
        AccountRoleEnum Role,
        bool IsActive = true
    ) : IRequest<ApiResponse<AccountCreatedResponse>>;
}
