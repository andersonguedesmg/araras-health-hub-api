using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdownOptions
{
    public class GetPresentationFormDropdownOptionsQueryHandler : IRequestHandler<GetPresentationFormDropdownOptionsQuery, ApiResponse<List<PresentationFormNameDto>>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public GetPresentationFormDropdownOptionsQueryHandler(IPresentationFormRepository presentationFormRepository, IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<PresentationFormNameDto>>> Handle(GetPresentationFormDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _presentationFormRepository.GetQueryable();
            query = query
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name);

            var dropdownOptions = await query
                .Select(s => new PresentationFormNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<PresentationFormNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
