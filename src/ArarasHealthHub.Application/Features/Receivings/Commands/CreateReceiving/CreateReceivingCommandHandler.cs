using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving
{
    public class CreateReceivingCommandHandler : IRequestHandler<CreateReceivingCommand, ApiResponse<ReceivingDto>>
    {
        private readonly IReceivingRepository _receivingRepository;
        private readonly IReceivingItemRepository _receivingItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateReceivingCommandHandler(
            IReceivingRepository receivingRepository,
            IReceivingItemRepository receivingItemRepository,
            IProductRepository productRepository,
            IMapper mapper,
            IApplicationDbContext context)
        {
            _receivingRepository = receivingRepository;
            _receivingItemRepository = receivingItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse<ReceivingDto>> Handle(CreateReceivingCommand request, CancellationToken cancellationToken)
        {
            var receiving = _mapper.Map<Receiving>(request);

            foreach (var itemCommand in request.Items)
            {
                if (!await _productRepository.ProductExists(itemCommand.ProductId))
                {
                    return new ApiResponse<ReceivingDto>(StatusCodes.Status400BadRequest, $"Produto com ID {itemCommand.ProductId} para um item do recebimento não encontrado.", null!);
                }

                var receivingItem = _mapper.Map<ReceivingItem>(itemCommand);
                receivingItem.TotalValue = itemCommand.Quantity * itemCommand.UnitValue;
                receiving.ReceivedItems.Add(receivingItem);
            }

            receiving.TotalValue = receiving.ReceivedItems.Sum(item => item.Quantity * item.UnitValue);

            await _receivingRepository.AddAsync(receiving);

            await _context.SaveChangesAsync(cancellationToken);

            var createdReceivingDto = _mapper.Map<ReceivingDto>(receiving);

            return new ApiResponse<ReceivingDto>(StatusCodes.Status201Created, "Recebimento criado com sucesso.", createdReceivingDto);
        }
    }
}
