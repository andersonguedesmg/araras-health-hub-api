using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class ForbiddenException : BaseAppException
    {
        public ForbiddenException(
            string message = "Você não possui permissão para executar esta ação.")
            : base(message, (int)HttpStatusCode.Forbidden)
        {
        }
    }
}
