using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public DateTime CreatedOn { get; protected set; }

        public DateTime? UpdatedOn { get; protected set; }

        public bool IsActive { get; protected set; }

        protected BaseEntity()
        {
            CreatedOn = DateTime.UtcNow;
            IsActive = true;
        }

        protected void SetUpdatedOn()
        {
            UpdatedOn = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            SetUpdatedOn();
        }

        public void Deactivate()
        {
            IsActive = false;
            SetUpdatedOn();
        }
    }
}
