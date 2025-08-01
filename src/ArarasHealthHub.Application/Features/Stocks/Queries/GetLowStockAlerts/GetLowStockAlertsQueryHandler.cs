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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetLowStockAlerts
{
    public class GetLowStockAlertsQueryHandler : IRequestHandler<GetLowStockAlertsQuery, ApiResponse<List<StockDto>>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetLowStockAlertsQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<StockDto>>> Handle(GetLowStockAlertsQuery request, CancellationToken cancellationToken)
        {
            var lowStockItems = await _stockRepository.GetLowStockAsync();

            var lowStockDtos = _mapper.Map<List<StockDto>>(lowStockItems);

            if (lowStockDtos == null || lowStockDtos.Count == 0)
            {
                return new ApiResponse<List<StockDto>>(StatusCodes.Status200OK, "Nenhum produto com estoque baixo encontrado.", new List<StockDto>());
            }

            return new ApiResponse<List<StockDto>>(StatusCodes.Status200OK, "Lista de produtos com estoque baixo retornada com sucesso.", lowStockDtos);
        }
    }
}
