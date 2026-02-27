using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory
{
    public class CreateMainCategoryCommandHandler : IRequestHandler<CreateMainCategoryCommand, Result<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public CreateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(
            CreateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existingMainCategory = await _mainCategoryRepository.GetByMainCategoryNameAsync(request.Name, cancellationToken);

            if (existingMainCategory is not null)
                throw new BusinessRuleException("Já existe uma categoria principal com o nome informado.");

            var mainCategory = _mapper.Map<MainCategory>(request);

            await _mainCategoryRepository.AddAsync(mainCategory, cancellationToken);

            return Result<int>.Success(mainCategory.Id, "Funcionário criado com sucesso.");
        }
    }
}
