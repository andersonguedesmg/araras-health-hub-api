using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Picking;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Services.Orders.Picking
{
    public class OrderPickingService : IOrderPickingService
    {
        private readonly IMapper _mapper;
        private readonly IStockLotRepository _stockLotRepository;

        public OrderPickingService(
            IMapper mapper,
            IStockLotRepository stockLotRepository)
        {
            _mapper = mapper;
            _stockLotRepository = stockLotRepository;
        }

        public async Task<OrderPickingResponse> BuildPickingAsync(
            Order order,
            CancellationToken cancellationToken)
        {
            var response =
                _mapper.Map<OrderPickingResponse>(order);

            var productIds = order.OrderItems
                .Select(x => x.ProductId)
                .Distinct()
                .ToList();

            var lotsByProduct = await _stockLotRepository.GetAvailableLotsByProductsFEFOAsync(
                productIds,
                cancellationToken);

            foreach (var item in response.Items)
            {
                var remainingQuantity =
                    item.ApprovedQuantity;

                item.LotsToSeparate = [];

                if (remainingQuantity <= 0)
                    continue;

                if (!lotsByProduct.TryGetValue(
                        item.ProductId,
                        out var availableLots))
                {
                    continue;
                }

                foreach (var lot in availableLots)
                {
                    if (remainingQuantity <= 0)
                        break;

                    var quantityToSeparate =
                        Math.Min(
                            remainingQuantity,
                            lot.AvailableQuantity);

                    if (quantityToSeparate <= 0)
                        continue;

                    item.LotsToSeparate.Add(
                        new OrderItemLotPickingResponse(
                            lot.Id,
                            lot.Batch,
                            lot.ExpiryDate,
                            quantityToSeparate,
                            lot.UnitValue));

                    remainingQuantity -=
                        quantityToSeparate;
                }
            }

            return response;
        }
    }
}
