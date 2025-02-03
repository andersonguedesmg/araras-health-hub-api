using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
