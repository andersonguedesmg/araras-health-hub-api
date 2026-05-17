using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.SetMinimumStockLevel
{
    public class SetMinimumStockLevelCommandHandler : IRequestHandler<SetMinimumStockLevelCommand, Result>
    {
        private readonly IApplicationDbContext _dbContext;

        public SetMinimumStockLevelCommandHandler(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(
            SetMinimumStockLevelCommand request,
            CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(
                    x => x.ProductId == request.ProductId,
                    cancellationToken);

            if (stock is null)
            {
                throw new NotFoundException(
                    $"Estoque do produto {request.ProductId} não encontrado.");
            }

            stock.SetMinimumQuantity(
                request.MinimumQuantity);

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result.Success(
                "Quantidade mínima atualizada com sucesso.");
        }
    }
}
