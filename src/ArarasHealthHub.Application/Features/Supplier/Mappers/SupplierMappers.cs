using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Supplier.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Supplier.Mappers
{
    public static class SupplierMappers
    {
        public static SupplierDto ToSupplierDto(this SupplierDto SupplierModel)
        {
            return new SupplierDto
            {
                Id = SupplierModel.Id,
                Name = SupplierModel.Name,
                Cnpj = SupplierModel.Cnpj,
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

        public static SupplierDto ToSupplierFromCreateDto(this CreateSupplierRequestDto SupplierModelDto)
        {
            return new SupplierDto
            {
                Name = SupplierModelDto.Name,
                Cnpj = SupplierModelDto.Cnpj,
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
