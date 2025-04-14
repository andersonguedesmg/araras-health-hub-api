using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Product;
using araras_health_hub_api.Dtos.User;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Format = productModel.Format,
                Category = productModel.Category,
                CreatedOn = productModel.CreatedOn,
                UpdatedOn = productModel.UpdatedOn,
                IsActive = productModel.IsActive,
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductRequestDto productrModelDto)
        {
            return new Product
            {
                Name = productrModelDto.Name,
                Description = productrModelDto.Description,
                Format = productrModelDto.Format,
                Category = productrModelDto.Category,
                CreatedOn = productrModelDto.CreatedOn,
                IsActive = productrModelDto.IsActive,
            };
        }
    }
}
