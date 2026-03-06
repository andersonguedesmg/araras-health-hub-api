using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory
{
    public class DeactivateSubCategoryCommandHandler : IRequestHandler<DeactivateSubCategoryCommand, Result>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public DeactivateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<Result> Handle(
            DeactivateSubCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .GetByIdAsync(command.Id, cancellationToken);

            if (subCategory is null)
                throw new NotFoundException("Subcategoria não foi encontrada.");

            if (!subCategory.IsActive)
                throw new BusinessRuleException("A subcategoria já está inativa.");

            subCategory.Deactivate();

            await _subCategoryRepository.UpdateAsync(
                subCategory,
                cancellationToken);

            return Result.Success("Subcategoria desativada com sucesso.");
        }
    }
}
