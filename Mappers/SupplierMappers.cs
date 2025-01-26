using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class SupplierMappers
    {
        public static SupplierDto ToSupplierDto(this Supplier SupplierModel)
        {
            return new SupplierDto
            {
                Id = SupplierModel.Id,
                Name = SupplierModel.Name,
                Address = SupplierModel.Address,
                Number = SupplierModel.Number,
                Neighborhood = SupplierModel.Neighborhood,
                City = SupplierModel.City,
                State = SupplierModel.State,
                Cep = SupplierModel.Cep,
                Email = SupplierModel.Email,
                Phone = SupplierModel.Phone,
                CreatedOn = SupplierModel.CreatedOn,
                UpdatedOn = SupplierModel.UpdatedOn,
                IsActive = SupplierModel.IsActive,
            };
        }

        public static Supplier ToSupplierFromCreateDto(this CreateSupplierRequestDto SupplierModelDto)
        {
            return new Supplier
            {
                Name = SupplierModelDto.Name,
                Address = SupplierModelDto.Address,
                Number = SupplierModelDto.Number,
                Neighborhood = SupplierModelDto.Neighborhood,
                City = SupplierModelDto.City,
                State = SupplierModelDto.State,
                Cep = SupplierModelDto.Cep,
                Email = SupplierModelDto.Email,
                Phone = SupplierModelDto.Phone,
                CreatedOn = SupplierModelDto.CreatedOn,
                UpdatedOn = SupplierModelDto.UpdatedOn,
                IsActive = SupplierModelDto.IsActive,
            };
        }
    }
}
