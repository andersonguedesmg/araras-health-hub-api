using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, Result<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public CreateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<Result<int>> Handle(
            CreateSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.Trim();

            var subCategoryWithSameName =
                await _subCategoryRepository.GetBySubCategoryNameAndMainCategoryIdAsync(
                    normalizedName,
                    request.MainCategoryId,
                    cancellationToken);

            if (subCategoryWithSameName is not null)
                throw new BusinessRuleException("Já existe uma subcategoria com o nome informado.");

            var mainCategory =
                await _mainCategoryRepository.GetByIdAsync(
                    request.MainCategoryId,
                    cancellationToken);

            if (mainCategory is null || !mainCategory.IsActive)
                throw new BusinessRuleException("Categoria principal inválida ou inativa.");

            var subCategory = new SubCategory(
                normalizedName,
                request.MainCategoryId
            );

            await _subCategoryRepository.AddAsync(
                subCategory,
                cancellationToken);

            return Result<int>.Success(
                subCategory.Id,
                "Subcategoria criada com sucesso.");
        }
    }
}
