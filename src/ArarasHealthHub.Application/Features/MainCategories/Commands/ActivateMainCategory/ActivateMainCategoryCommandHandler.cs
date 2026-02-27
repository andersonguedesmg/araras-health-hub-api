using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.ActivateMainCategory
{
    public class ActivateMainCategoryCommandHandler : IRequestHandler<ActivateMainCategoryCommand, Result>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ActivateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Result> Handle(
            ActivateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            if (category.IsActive)
                throw new BusinessRuleException("A categoria principal já está ativa.");

            category.Activate();

            await _mainCategoryRepository.UpdateAsync(category, cancellationToken);

            return Result.Success("Categoria principal ativada com sucesso.");

        }
    }
}
