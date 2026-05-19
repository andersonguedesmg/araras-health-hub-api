using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Common.Interfaces.Providers
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
