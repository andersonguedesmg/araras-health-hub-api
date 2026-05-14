using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Exceptions
{
    public class DomainRuleException: DomainException
    {
        public DomainRuleException(string message)
            : base(message)
        {
        }
    }
}
