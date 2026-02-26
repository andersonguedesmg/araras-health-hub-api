using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class NotFoundException : BaseAppException
    {
        public NotFoundException(
            string message)
            : base(message, (int)HttpStatusCode.NotFound)
        {
        }
    }
}
