using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class PresentationForm : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;

        public ICollection<Product> Products { get; private set; } = new List<Product>();

        private PresentationForm() { }

        public PresentationForm(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
