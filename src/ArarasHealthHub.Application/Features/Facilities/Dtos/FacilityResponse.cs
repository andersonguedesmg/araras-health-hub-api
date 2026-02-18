using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Facilities.Dtos
{
    public sealed record FacilityResponse(
        int Id,
        string Name,
        string Cnes,
        string Cep,
        string Street,
        string Number,
        string? Complement,
        string Neighborhood,
        string City,
        string State,
        string Email,
        string Phone
    );
}
