using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview
{
    public class GetStockOverviewQueryHandler : IRequestHandler<GetStockOverviewQuery, PagedResponse<StockOverviewDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockOverviewQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockOverviewDto>> Handle(GetStockOverviewQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _stockRepository.GetTotalCountAsync();

            var stocks = await _stockRepository.GetStockOverviewAsync(
                request.PageNumber,
                request.PageSize,
                request.OrderBy,
                request.SortOrder
            );

            var stockOverviewDtos = _mapper.Map<List<StockOverviewDto>>(stocks);

            return new PagedResponse<StockOverviewDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                stockOverviewDtos
            );
        }
    }
}
