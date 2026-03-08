using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;

namespace ArarasHealthHub.Application.Features.Facilities.Responses
{
    public record FacilityListItemResponse(
        int Id,
        string Name,
        string Cnes,
        AddressResponse Address,
        ContactResponse Contact,
        bool IsActive
    );
}
