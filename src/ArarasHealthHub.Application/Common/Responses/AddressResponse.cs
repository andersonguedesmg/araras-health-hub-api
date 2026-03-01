using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Common.Responses
{
    public record AddressResponse(
        string Street,
        string Number,
        string? Complement,
        string Neighborhood,
        string City,
        string State,
        string Cep
    );
}
