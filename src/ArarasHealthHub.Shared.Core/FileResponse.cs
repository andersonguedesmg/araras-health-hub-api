using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Core
{
    public class FileResponse
    {
        public byte[] Content { get; init; } = Array.Empty<byte>();
        public string ContentType { get; init; } = "application/octet-stream";
        public string FileName { get; init; } = string.Empty;
    }
}
