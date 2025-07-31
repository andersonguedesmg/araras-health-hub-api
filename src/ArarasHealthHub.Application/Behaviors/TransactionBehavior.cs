using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArarasHealthHub.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ITransactionalRequest
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;

        public TransactionBehavior(IApplicationDbContext dbContext, ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? transaction = null;

            try
            {
                _logger.LogInformation("--- Iniciando transação de banco de dados para a requisição {CommandName}...", typeof(TRequest).Name);

                transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

                response = await next();

                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                _logger.LogInformation("--- Transação comitada com sucesso para a requisição {CommandName}.", typeof(TRequest).Name);

                return response;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    _logger.LogError(ex, "--- Transação revertida devido a um erro para a requisição {CommandName}.", typeof(TRequest).Name);
                }
                else
                {
                    _logger.LogError(ex, "--- Erro na requisição {CommandName} e a transação não foi iniciada ou acessível.", typeof(TRequest).Name);
                }
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
