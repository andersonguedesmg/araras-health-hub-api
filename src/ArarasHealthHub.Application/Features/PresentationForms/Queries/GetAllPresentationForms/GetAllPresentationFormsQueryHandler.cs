using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms
{
    public class GetAllPresentationFormsQueryHandler : IRequestHandler<GetAllPresentationFormsQuery, PagedResponse<PresentationFormDto>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public GetAllPresentationFormsQueryHandler(IPresentationFormRepository presentationFormRepository, IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<PresentationFormDto>> Handle(GetAllPresentationFormsQuery request, CancellationToken cancellationToken)
        {
            var presentationFormsQuery = _presentationFormRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();

                presentationFormsQuery = presentationFormsQuery.Where(e =>
                    e.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await presentationFormsQuery.CountAsync(cancellationToken);

            IOrderedQueryable<PresentationForm> orderedQuery;
            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? presentationFormsQuery.OrderByDescending(p => p.Name)
                        : presentationFormsQuery.OrderBy(p => p.Name);
                    break;
                default:
                    orderedQuery = presentationFormsQuery.OrderBy(e => e.Name);
                    break;
            }

            var pagedPresentationForms = await orderedQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var presentationFormDtos = _mapper.Map<List<PresentationFormDto>>(pagedPresentationForms);

            return new PagedResponse<PresentationFormDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                presentationFormDtos
            );
        }
    }
}
