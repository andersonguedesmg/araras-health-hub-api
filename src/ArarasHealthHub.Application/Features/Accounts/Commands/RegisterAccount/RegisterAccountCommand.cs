using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount
{
    public class RegisterAccountCommand : IRequest<ApiResponse<NewAccountDto>>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int FacilityId { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
