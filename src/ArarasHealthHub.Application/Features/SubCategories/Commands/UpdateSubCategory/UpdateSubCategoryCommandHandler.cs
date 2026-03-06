using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, Result>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public UpdateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<Result> Handle(
            UpdateSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var subCategory =
                await _subCategoryRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (subCategory is null)
                throw new NotFoundException("Subcategoria não encontrada.");

            var normalizedName = request.Name.Trim();

            var subCategoryWithSameName =
                await _subCategoryRepository.GetBySubCategoryNameAndMainCategoryIdAsync(
                    normalizedName,
                    request.MainCategoryId,
                    cancellationToken);

            if (subCategoryWithSameName is not null &&
                subCategoryWithSameName.Id != subCategory.Id)
            {
                throw new BusinessRuleException("Já existe uma subcategoria com o nome informado.");
            }

            var mainCategory =
                await _mainCategoryRepository.GetByIdAsync(
                    request.MainCategoryId,
                    cancellationToken);

            if (mainCategory is null || !mainCategory.IsActive)
                throw new BusinessRuleException("Categoria principal inválida ou inativa.");

            subCategory.Update(
                normalizedName,
                request.MainCategoryId);

            await _subCategoryRepository.UpdateAsync(
                subCategory,
                cancellationToken);

            return Result.Success("Subcategoria atualizada com sucesso.");
        }
    }
}
