using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById
{
    public class GetMainCategoryByIdQueryHandler : IRequestHandler<GetMainCategoryByIdQuery, Result<MainCategoryResponse>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public GetMainCategoryByIdQueryHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<Result<MainCategoryResponse>> Handle(
            GetMainCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var mainCategory = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (mainCategory is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            var response = new MainCategoryResponse(
                mainCategory.Id,
                mainCategory.Name,
                mainCategory.CreatedOn,
                mainCategory.UpdatedOn,
                mainCategory.IsActive
            );

            return Result<MainCategoryResponse>.Success(response, "Categoria principal encontrada com sucesso.");
        }
    }
}
