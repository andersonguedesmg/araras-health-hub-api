using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;

namespace ArarasHealthHub.Application.Features.SubCategories.Responses
{
    public record SupplierResponse(
        int Id,
        string LegalName,
        string TradeName,
        string Cnpj,
        AddressResponse Address,
        ContactResponse Contact,
        DateTime CreatedOn,
        DateTime? UpdatedOn,
        bool IsActive
    );
}
