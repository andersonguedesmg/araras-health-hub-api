using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Accounts.Responses
{
    public sealed record AccountMinimalResponse(
        int Id,
        string UserName
    );
}
