using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Product.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Product.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this ProductDto productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                DosageForm = productModel.DosageForm,
                Category = productModel.Category,
                CreatedOn = productModel.CreatedOn,
                UpdatedOn = productModel.UpdatedOn,
                IsActive = productModel.IsActive,
            };
        }

        public static ProductDto ToProductFromCreateDto(this CreateProductRequestDto productrModelDto)
        {
            return new ProductDto
            {
                Name = productrModelDto.Name,
                Description = productrModelDto.Description,
                DosageForm = productrModelDto.DosageForm,
                Category = productrModelDto.Category,
                CreatedOn = productrModelDto.CreatedOn,
                IsActive = productrModelDto.IsActive,
            };
        }
    }
}
