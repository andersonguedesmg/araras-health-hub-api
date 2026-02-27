using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById
{
    public class GetMainCategoryByIdQueryHandler : IRequestHandler<GetMainCategoryByIdQuery, Result<MainCategoryResponse>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public GetMainCategoryByIdQueryHandler(
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<Result<MainCategoryResponse>> Handle(
            GetMainCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var mainCategory = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (mainCategory is null)
                throw new NotFoundException("Categoria principal não foi encontrada.");

            var response = _mapper.Map<MainCategoryResponse>(mainCategory);

            return Result<MainCategoryResponse>.Success(response, "Categoria principal encontrada com sucesso.");
        }
    }
}
