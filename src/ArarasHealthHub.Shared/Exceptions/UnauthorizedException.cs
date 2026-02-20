using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class UnauthorizedException : BaseAppException
    {
        public UnauthorizedException(string message = "Acesso não autorizado.")
            : base(message, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}
