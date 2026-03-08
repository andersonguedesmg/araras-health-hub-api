using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.DeactivatePackagingType
{
    public class DeactivatePackagingTypeCommandHandler : IRequestHandler<DeactivatePackagingTypeCommand, Result>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public DeactivatePackagingTypeCommandHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<Result> Handle(
            DeactivatePackagingTypeCommand request,
            CancellationToken cancellationToken)
        {
            var packagingType = await _packagingTypeRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (packagingType is null)
                throw new NotFoundException("Tipo de embalagem não foi encontrado.");

            if (!packagingType.IsActive)
                throw new BusinessRuleException("O tipo de embalagem já está inativo.");

            packagingType.Deactivate();

            await _packagingTypeRepository.UpdateAsync(packagingType, cancellationToken);

            return Result.Success("Tipo de embalagem desativado com sucesso.");
        }
    }
}
