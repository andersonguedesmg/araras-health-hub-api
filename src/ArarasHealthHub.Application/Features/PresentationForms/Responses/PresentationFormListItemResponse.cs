using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.PresentationForms.Responses
{
    public record PresentationFormListItemResponse(
        int Id,
        string Name,
        bool IsActive
    );
}
