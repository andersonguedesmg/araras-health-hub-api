using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public class ApplicationValidationException : BaseAppException
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }

        public ApplicationValidationException(
            IReadOnlyDictionary<string, string[]> errors)
            : base("Ocorreram erros de validação.",
                  (int)HttpStatusCode.BadRequest)
        {
            Errors = errors;
        }
    }
}
