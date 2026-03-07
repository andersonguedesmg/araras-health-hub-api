using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result<int>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Result<int>> Handle(
            CreateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository
                .ExistsByCnpjAsync(request.Cnpj, null, cancellationToken);

            if (existingSupplier)
                throw new BusinessRuleException("Já existe fornecedor com este CNPJ.");

            var supplier = new Supplier(
                request.LegalName,
                request.TradeName,
                request.Cnpj,
                new Address(
                    request.Address.Cep,
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.Neighborhood,
                    request.Address.City,
                    request.Address.State,
                    request.Address.Complement
                ),
                new Contact(
                    request.Contact.Email,
                    request.Contact.Phone
                )
            );

            await _supplierRepository.AddAsync(supplier, cancellationToken);

            return Result<int>.Success(
                supplier.Id,
                "Fornecedor criado com sucesso.");
        }
    }
}
