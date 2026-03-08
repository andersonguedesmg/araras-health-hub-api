using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class PackagingType : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private PackagingType() { }

        public PackagingType(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name.Trim();
            SetUpdatedOn();
        }
    }
}
