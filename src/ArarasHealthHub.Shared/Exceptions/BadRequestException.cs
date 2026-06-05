using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class BadRequestException : BaseAppException
    {
        public BadRequestException(string message) : base(message, (int)HttpStatusCode.BadRequest) { }
    }
}
