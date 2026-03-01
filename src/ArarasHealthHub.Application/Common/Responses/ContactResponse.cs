using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Common.Responses
{
    public record ContactResponse(
        string Email,
        string Phone
    );
}
