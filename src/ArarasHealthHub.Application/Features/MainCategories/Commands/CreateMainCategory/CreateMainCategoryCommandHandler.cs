using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory
{
    public class CreateMainCategoryCommandHandler : IRequestHandler<CreateMainCategoryCommand, ApiResponse<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public CreateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<int>> Handle(
            CreateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var name = request.Name.Trim();

            var alreadyExists = await _mainCategoryRepository
                .GetQueryable()
                .AnyAsync(
                    c => c.Name.ToLower() == name.ToLower(),
                    cancellationToken
                );

            if (alreadyExists)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.MainCategory)
                );
            }

            var entity = new MainCategory
            {
                Name = name
            };

            await _mainCategoryRepository.AddAsync(entity, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.MainCategory),
                entity.Id
            );
        }
    }
}
