using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier
{
    public class DeactivateSupplierCommandHandler : IRequestHandler<DeactivateSupplierCommand, Result>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeactivateSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Result> Handle(
            DeactivateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (supplier is null)
                throw new NotFoundException("Funcionário não foi encontrado.");

            if (!supplier.IsActive)
                throw new BusinessRuleException("O funcionário já está inativo.");

            supplier.Deactivate();

            await _supplierRepository
                .UpdateAsync(supplier, cancellationToken);

            return Result.Success("Funcionário desativado com sucesso.");
        }
    }
}
