using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Account.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.MinValue;

        public string Role { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public int FacilityId { get; set; }
    }
}
