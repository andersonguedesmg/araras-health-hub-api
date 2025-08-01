using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId
{
    public class GetStockByProductIdQueryHandler : IRequestHandler<GetStockByProductIdQuery, ApiResponse<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockByProductIdQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockDto>> Handle(GetStockByProductIdQuery request, CancellationToken cancellationToken)
        {
            var stock = await _stockRepository.GetByProductIdAsync(request.ProductId);

            if (stock == null)
            {
                return new ApiResponse<StockDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Estoque para o produto", request.ProductId), false);
            }

            var stockDto = _mapper.Map<StockDto>(stock);
            return new ApiResponse<StockDto>(StatusCodes.Status200OK, ApiMessages.StockSearchByIdSuccessful, stockDto);
        }
    }
}
