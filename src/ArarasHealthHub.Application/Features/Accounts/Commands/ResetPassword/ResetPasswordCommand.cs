using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword
{
    public record ResetPasswordCommand(string UserName, string NewPassword) : IRequest<ApiResponse<bool>>;
}
