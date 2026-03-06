using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory
{
    public class ActivateSubCategoryCommandHandler : IRequestHandler<ActivateSubCategoryCommand, Result>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ActivateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Result> Handle(
            ActivateSubCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .GetByIdAsync(command.Id, cancellationToken);

            if (subCategory is null)
                throw new NotFoundException("Subcategoria não foi encontrada.");

            if (subCategory.IsActive)
                throw new BusinessRuleException("A subcategoria já está ativa.");

            var mainCategory = await _mainCategoryRepository
                .GetByIdAsync(subCategory.MainCategoryId, cancellationToken);

            if (mainCategory is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            if (!mainCategory.IsActive)
                throw new BusinessRuleException("Não é possível ativar uma subcategoria de uma categoria principal inativa.");

            subCategory.Activate();

            await _subCategoryRepository.UpdateAsync(
                subCategory,
                cancellationToken);

            return Result.Success("Subcategoria ativada com sucesso.");
        }
    }
}
