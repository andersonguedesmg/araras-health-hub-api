using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Core
{
    public abstract class ApiResponseBase
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public Dictionary<string, List<string>>? Errors { get; set; }
    }
}
