using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ChangeStatusSubCategory
{
    public class ChangeStatusSubCategoryCommandHandler : IRequestHandler<ChangeStatusSubCategoryCommand, ApiResponse<bool>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public ChangeStatusSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusSubCategoryCommand command, CancellationToken cancellationToken)
        {
            var existingSubCategory = await _subCategoryRepository.GetByIdAsync(command.Id);

            if (existingSubCategory == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Subcategoria"), false);
            }

            if (command.IsActive)
            {
                existingSubCategory.Activate();
            }
            else
            {
                existingSubCategory.Deactivate();
            }

            await _subCategoryRepository.UpdateAsync(existingSubCategory);

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Subcategoria") : ApiMessages.DeactivatedSuccessfully("Subcategoria");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
