using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(int userId, string userName, IEnumerable<string> roles);
    }
}
