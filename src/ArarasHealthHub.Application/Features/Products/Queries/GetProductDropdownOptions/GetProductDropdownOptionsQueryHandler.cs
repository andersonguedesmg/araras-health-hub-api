using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdownOptions
{
    public class GetProductDropdownOptionsQueryHandler : IRequestHandler<GetProductDropdownOptionsQuery, ApiResponse<List<ProductNameDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductDropdownOptionsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ProductNameDto>>> Handle(GetProductDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.AsQueryable();

            query = query.Where(s => s.IsActive);

            query = query.OrderBy(s => s.Name);

            var activeProducts = await query.ToListAsync(cancellationToken);

            var dropdownOptions = _mapper.Map<List<ProductNameDto>>(activeProducts);

            return new ApiResponse<List<ProductNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
