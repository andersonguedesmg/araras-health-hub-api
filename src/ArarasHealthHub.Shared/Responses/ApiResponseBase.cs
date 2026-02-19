using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Responses
{
    public abstract class ApiResponseBase
    {
        public int StatusCode { get; protected set; }
        public string Message { get; protected set; } = string.Empty;
        public bool Success { get; protected set; }
        public IReadOnlyDictionary<string, IReadOnlyList<string>>? Errors { get; protected set; }
    }
}
