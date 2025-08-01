using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateMinQuantity
{
    public class UpdateMinQuantityCommandHandler : IRequestHandler<UpdateMinQuantityCommand, ApiResponse<StockDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMinQuantityCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockDto>> Handle(UpdateMinQuantityCommand request, CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.ProductId == request.ProductId, cancellationToken);

            if (stock == null)
            {
                return new ApiResponse<StockDto>(StatusCodes.Status404NotFound, $"Estoque para o produto com ID {request.ProductId} não encontrado.", false);
            }

            if (request.NewMinQuantity < 0)
            {
                return new ApiResponse<StockDto>(StatusCodes.Status404NotFound, "A quantidade mínima não pode ser um valor negativo.", false);
            }

            stock.MinQuantity = request.NewMinQuantity;

            await _dbContext.SaveChangesAsync(cancellationToken);

            var stockDto = _mapper.Map<StockDto>(stock);
            return new ApiResponse<StockDto>(StatusCodes.Status200OK, "Quantidade mínima atualizada com sucesso.", stockDto);
        }
    }
}
