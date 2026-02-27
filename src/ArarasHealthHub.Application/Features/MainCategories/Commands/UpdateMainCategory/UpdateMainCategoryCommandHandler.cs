using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory
{
    public class UpdateMainCategoryCommandHandler : IRequestHandler<UpdateMainCategoryCommand, Result>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existingMainCategory =
                await _mainCategoryRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (existingMainCategory is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");


            _mapper.Map(request, existingMainCategory);
            existingMainCategory.SetUpdatedOn();

            await _mainCategoryRepository.UpdateAsync(
                existingMainCategory,
                cancellationToken);

            return Result.Success("Categoria principal atualizada com sucesso.");
        }
    }
}
