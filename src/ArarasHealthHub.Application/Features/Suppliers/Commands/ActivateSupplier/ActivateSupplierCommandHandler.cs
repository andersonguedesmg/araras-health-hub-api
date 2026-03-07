using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier
{
    public class ActivateSupplierCommandHandler : IRequestHandler<ActivateSupplierCommand, Result>
    {
        private readonly ISupplierRepository _supplierRepository;

        public ActivateSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Result> Handle(
            ActivateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (supplier is null)
                throw new NotFoundException("Fornecedor não foi encontrado.");

            if (supplier.IsActive)
                throw new BusinessRuleException("O fornecedor já está ativo.");

            supplier.Activate();

            await _supplierRepository
                .UpdateAsync(supplier, cancellationToken);

            return Result.Success("Fornecedor ativado com sucesso.");
        }
    }
}
