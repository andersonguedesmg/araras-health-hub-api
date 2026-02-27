using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.DeactivateMainCategory
{
    public class DeactivateMainCategoryCommandHandler : IRequestHandler<DeactivateMainCategoryCommand, Result>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public DeactivateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Result> Handle(
            DeactivateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            if (!category.IsActive)
                throw new BusinessRuleException("A categoria principal já está inativa.");

            category.Deactivate();

            await _mainCategoryRepository.UpdateAsync(category, cancellationToken);

            return Result.Success("Categoria principal desativada com sucesso.");
        }
    }
}
