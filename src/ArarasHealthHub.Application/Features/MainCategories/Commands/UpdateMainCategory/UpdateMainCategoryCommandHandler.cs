using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory
{
    public class UpdateMainCategoryCommandHandler : IRequestHandler<UpdateMainCategoryCommand, Result>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public UpdateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Result> Handle(
            UpdateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var mainCategory =
                await _mainCategoryRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (mainCategory is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            var normalizedName = request.Name.Trim();

            var existing = await _mainCategoryRepository
                .GetByMainCategoryNameAsync(normalizedName, cancellationToken);

            if (existing is not null && existing.Id != request.Id)
                throw new BusinessRuleException("Já existe uma categoria principal com o nome informado.");

            mainCategory.Update(normalizedName);

            await _mainCategoryRepository.UpdateAsync(mainCategory, cancellationToken);

            return Result.Success("Categoria principal atualizada com sucesso.");
        }
    }
}
