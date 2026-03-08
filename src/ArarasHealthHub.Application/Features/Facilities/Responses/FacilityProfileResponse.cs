using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;

namespace ArarasHealthHub.Application.Features.Facilities.Responses
{
    public record FacilityProfileResponse(
        int Id,
        string Name,
        string Cnes,
        AddressResponse Address,
        ContactResponse Contact,
        DateTime CreatedOn,
        DateTime? UpdatedOn,
        bool IsActive,
        IReadOnlyCollection<FacilityAccountResponse> Accounts
    );
}
