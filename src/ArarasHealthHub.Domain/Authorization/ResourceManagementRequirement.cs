using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ArarasHealthHub.Domain.Authorization
{
    public class ResourceManagementRequirement : IAuthorizationRequirement
    {
        public ResourceManagementRequirement() { }
    }
}
