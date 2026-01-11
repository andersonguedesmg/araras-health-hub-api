using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.ChangeStatusMainCategory
{
    public class ChangeStatusMainCategoryCommandHandler : IRequestHandler<ChangeStatusMainCategoryCommand, ApiResponse<bool>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ChangeStatusMainCategoryCommandHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusMainCategoryCommand command, CancellationToken cancellationToken)
        {
            var existingMainCategory = await _mainCategoryRepository.GetByIdAsync(command.Id);

            if (existingMainCategory == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Categoria principal"), false);
            }

            if (command.IsActive)
            {
                existingMainCategory.Activate();
            }
            else
            {
                existingMainCategory.Deactivate();
            }

            await _mainCategoryRepository.UpdateAsync(existingMainCategory);

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Categoria principal") : ApiMessages.DeactivatedSuccessfully("Categoria principal");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
