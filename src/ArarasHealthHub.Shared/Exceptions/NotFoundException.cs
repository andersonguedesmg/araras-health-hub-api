using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class NotFoundException : BaseAppException
    {
        public NotFoundException(string resourceName, object key)
            : base($"{resourceName} com identificador '{key}' não foi encontrado.",
                (int)HttpStatusCode.NotFound)
        {
        }
    }
}
