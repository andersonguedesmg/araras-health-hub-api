using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword
{
    public record ResetPasswordCommand(string UserName, string NewPassword) : IRequest<ApiResponseO<bool>>;
}
