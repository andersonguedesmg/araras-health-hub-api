using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.DeleteMainCategory
{
    public class DeleteMainCategoryCommandHandler : IRequestHandler<DeleteMainCategoryCommand, ApiResponse<object>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public DeleteMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existingMainCategory =
                await _mainCategoryRepository.GetByIdAsync(request.Id);

            if (existingMainCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Categoria principal")
                );
            }

            await _mainCategoryRepository.DeleteAsync(existingMainCategory);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Categoria principal")
            );
        }
    }
}
