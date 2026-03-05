using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class MainCategory : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public ICollection<SubCategory> SubCategories { get; private set; } = new List<SubCategory>();
        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private MainCategory() { }

        public MainCategory(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
