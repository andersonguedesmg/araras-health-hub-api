using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.CreatePackagingType
{
    public class CreatePackagingTypeCommandHandler : IRequestHandler<CreatePackagingTypeCommand, Result<int>>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public CreatePackagingTypeCommandHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<Result<int>> Handle(
            CreatePackagingTypeCommand request,
            CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.Trim();

            var packagingTypeWithSameName = await _packagingTypeRepository
                .GetByPackagingTypeNameAsync(normalizedName, cancellationToken);

            if (packagingTypeWithSameName is not null)
                throw new BusinessRuleException("Já existe um tipo de embalagem com o nome informado.");

            var packagingType = new PackagingType(
                normalizedName
            );

            await _packagingTypeRepository.AddAsync(
                packagingType,
                cancellationToken);

            return Result<int>.Success(
                packagingType.Id,
                "Tipo de embalagem criado com sucesso.");
        }
    }
}
