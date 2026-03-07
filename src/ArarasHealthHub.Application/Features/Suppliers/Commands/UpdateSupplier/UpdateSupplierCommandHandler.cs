using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result>
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Result> Handle(
            UpdateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (supplier is null)
                throw new NotFoundException("Fornecedor não encontrado.");

            var duplicate = await _supplierRepository
                .ExistsByCnpjAsync(request.Cnpj, request.Id, cancellationToken);

            if (duplicate)
                throw new BusinessRuleException("Já existe fornecedor com este CNPJ.");

            supplier.Update(
                request.LegalName,
                request.TradeName,
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

            await _supplierRepository.UpdateAsync(supplier, cancellationToken);

            return Result.Success("Fornecedor atualizado com sucesso.");
        }
    }
}
