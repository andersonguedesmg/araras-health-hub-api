using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails
{
    public class GetOrderPickingDetailsQueryHandler : IRequestHandler<GetOrderPickingDetailsQuery, ApiResponseO<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IStockLotRepository _stockLotRepo;
        private readonly IMapper _mapper;

        public GetOrderPickingDetailsQueryHandler(IOrderRepository orderRepo, IStockLotRepository stockLotRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _stockLotRepo = stockLotRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<OrderDto>> Handle(GetOrderPickingDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdWithItemsAsync(request.Id);

            if (order == null)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Pedido"), false);
            }

            if (order.OrderStatusId != (int)OrderStatusEnum.ReadyForPicking)
            {
                return new ApiResponseO<OrderDto>(StatusCodes.Status400BadRequest, ApiMessages.OrderCannotBeSeparated, false);
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                var remainingQuantityToAllocate = orderItemDto.ApprovedQuantity;

                orderItemDto.LotsToSeparate = new List<OrderItemLotDto>();

                if (remainingQuantityToAllocate <= 0) continue;

                var availableLots = await _stockLotRepo.GetAvailableLotsByProductIdFEFOAsync(orderItemDto.ProductId);

                foreach (var lot in availableLots)
                {
                    if (remainingQuantityToAllocate <= 0)
                    {
                        break;
                    }

                    var quantityFromThisLot = Math.Min(remainingQuantityToAllocate, lot.AvailableQuantity);

                    if (quantityFromThisLot > 0)
                    {
                        orderItemDto.LotsToSeparate.Add(new OrderItemLotDto
                        {
                            StockLotId = lot.Id,
                            Batch = lot.Batch,
                            ExpiryDate = lot.ExpiryDate,
                            QuantityToSeparate = quantityFromThisLot,
                            UnitValue = lot.UnitValue
                        });

                        remainingQuantityToAllocate -= quantityFromThisLot;
                    }
                }
            }

            return new ApiResponseO<OrderDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Pedido"), orderDto);
        }
    }
}
