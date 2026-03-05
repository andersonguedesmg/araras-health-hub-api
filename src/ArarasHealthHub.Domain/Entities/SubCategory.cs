using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public int MainCategoryId { get; private set; }
        public MainCategory? MainCategory { get; private set; }

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private SubCategory() { }

        public SubCategory(string name, int mainCategoryId)
        {
            Name = name;
            MainCategoryId = mainCategoryId;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
