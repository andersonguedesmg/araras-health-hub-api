using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;

        public int MainCategoryId { get; private set; }
        public MainCategory? MainCategory { get; private set; }

        public int SubCategoryId { get; private set; }
        public SubCategory? SubCategory { get; private set; }

        public int PackagingTypeId { get; private set; }
        public PackagingType? PackagingType { get; private set; }

        public Stock? Stock { get; private set; }

        private Product() { }

        public Product(
            string name,
            string description,
            int mainCategoryId,
            int subCategoryId,
            int packagingTypeId)
        {
            Name = name;
            Description = description;
            MainCategoryId = mainCategoryId;
            SubCategoryId = subCategoryId;
            PackagingTypeId = packagingTypeId;
        }

        public void Update(
            string name,
            string description,
            int mainCategoryId,
            int subCategoryId,
            int packagingTypeId)
        {
            Name = name.Trim();
            Description = description.Trim();
            MainCategoryId = mainCategoryId;
            SubCategoryId = subCategoryId;
            PackagingTypeId = packagingTypeId;

            SetUpdatedOn();
        }
    }
}
