using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.UpdatePackagingType
{
    public class UpdatePackagingTypeCommandHandler : IRequestHandler<UpdatePackagingTypeCommand, Result>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public UpdatePackagingTypeCommandHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<Result> Handle(
            UpdatePackagingTypeCommand request,
            CancellationToken cancellationToken)
        {
            var packagingType = await _packagingTypeRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (packagingType is null)
                throw new NotFoundException("Tipo de embalagem não foi encontrado.");

            var normalizedName = request.Name.Trim();

            var existing = await _packagingTypeRepository
                .GetByPackagingTypeNameAsync(normalizedName, cancellationToken);

            if (existing is not null && existing.Id != request.Id)
                throw new BusinessRuleException("Já existe um tipo de embalagem com o nome informado.");

            packagingType.Update(normalizedName);

            await _packagingTypeRepository.UpdateAsync(packagingType, cancellationToken);

            return Result.Success("Tipo de embalagem atualizado com sucesso.");
        }
    }
}
