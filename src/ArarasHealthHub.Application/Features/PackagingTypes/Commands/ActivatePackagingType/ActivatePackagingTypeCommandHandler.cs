using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.ActivatePackagingType
{
    public class ActivatePackagingTypeCommandHandler : IRequestHandler<ActivatePackagingTypeCommand, Result>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public ActivatePackagingTypeCommandHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<Result> Handle(
            ActivatePackagingTypeCommand request,
            CancellationToken cancellationToken)
        {
            var packagingType = await _packagingTypeRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (packagingType is null)
                throw new NotFoundException("Tipo de embalagem não foi encontrado.");

            if (packagingType.IsActive)
                throw new BusinessRuleException("O tipo de embalagem já está ativo.");

            packagingType.Activate();

            await _packagingTypeRepository.UpdateAsync(packagingType, cancellationToken);

            return Result.Success("Tipo de embalagem ativado com sucesso.");
        }
    }
}
