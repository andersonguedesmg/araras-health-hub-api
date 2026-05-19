using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Interfaces.Providers;

namespace ArarasHealthHub.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
