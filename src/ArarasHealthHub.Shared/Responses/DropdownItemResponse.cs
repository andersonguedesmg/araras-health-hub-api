using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Responses
{
    public record DropdownItemResponse(
        int Id,
        string Label
    );
}
