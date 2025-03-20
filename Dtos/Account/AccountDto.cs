using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Account
{
    public class AccountDto
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.MinValue;

        public bool IsActive { get; set; } = true;

        public int? DestinationId { get; set; }
    }
}
