using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? UpdatedOn { get; private set; }

        public bool IsActive { get; private set; }

        protected BaseEntity()
        {
            CreatedOn = DateTime.UtcNow;
            IsActive = true;
        }

        public void SetUpdatedOn()
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

        public void SetId(int id)
        {
            if (Id == 0)
            {
                Id = id;
            }
        }
    }
}
