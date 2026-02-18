using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser account);
    }
}
