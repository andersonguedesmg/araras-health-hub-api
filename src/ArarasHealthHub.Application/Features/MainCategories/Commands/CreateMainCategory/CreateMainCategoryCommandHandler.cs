using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory
{
    public class CreateMainCategoryCommandHandler : IRequestHandler<CreateMainCategoryCommand, Result<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;


        public CreateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;

        }

        public async Task<Result<int>> Handle(
            CreateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.Trim();

            var mainCategoryWithSameName = await _mainCategoryRepository.GetByMainCategoryNameAsync(normalizedName, cancellationToken);

            if (mainCategoryWithSameName is not null)
                throw new BusinessRuleException("Já existe uma categoria principal com o nome informado.");

            var mainCategory = new MainCategory(
                normalizedName
            );

            await _mainCategoryRepository.AddAsync(
                mainCategory,
                cancellationToken);

            return Result<int>.Success(mainCategory.Id, "Categoria principal criada com sucesso.");
        }
    }
}
