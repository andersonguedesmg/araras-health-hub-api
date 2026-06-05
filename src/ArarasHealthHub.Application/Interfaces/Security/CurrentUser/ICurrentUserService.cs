using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Interfaces.Security.CurrentUser
{
    public interface ICurrentUserService
    {
        int GetAccountId();

        int? GetFacilityId();

        bool IsAuthenticated();
    }
}
