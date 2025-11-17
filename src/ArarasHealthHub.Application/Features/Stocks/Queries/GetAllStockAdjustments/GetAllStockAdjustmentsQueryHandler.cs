using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments
{
    public class GetAllStockAdjustmentsQueryHandler : IRequestHandler<GetAllStockAdjustmentsQuery, PagedResponse<StockAdjustmentDto>>
    {
        private readonly IStockAdjustmentRepository _repo;
        private readonly IMapper _mapper;

        public GetAllStockAdjustmentsQueryHandler(IStockAdjustmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockAdjustmentDto>> Handle(GetAllStockAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var query = _repo.AsQueryable();

            // 1. Inclusão das entidades relacionadas (JOINs)
            query = query
                .Include(a => a.Responsible) // Funcionário Responsável
                .Include(a => a.Account) // Conta de Usuário
                .Include(a => a.AdjustmentItems)
                    .ThenInclude(ai => ai.Product); // Produto de cada item

            // 2. Filtro (SearchTerm)
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(a =>
                    a.Id.ToString().Contains(searchTermLower) ||
                    a.Reason.ToLower().Contains(searchTermLower) ||
                    a.Observation!.ToLower().Contains(searchTermLower) ||
                    a.AdjustmentDate.ToString().Contains(searchTermLower) ||
                    a.Type.ToString().ToLower().Contains(searchTermLower) ||

                    // Busca pelo nome do responsável
                    (a.Responsible != null && a.Responsible.Name.ToLower().Contains(searchTermLower)) ||
                    // Busca pelo nome de usuário da conta
                    (a.Account != null && a.Account.UserName!.ToLower().Contains(searchTermLower)) ||

                    // Busca nos itens de ajuste (Batch ou Nome do Produto)
                    a.AdjustmentItems.Any(ai =>
                        (ai.Batch != null && ai.Batch.ToLower().Contains(searchTermLower)) ||
                        (ai.Brand != null && ai.Brand.ToLower().Contains(searchTermLower)) ||
                        ai.Product.Name.ToLower().Contains(searchTermLower)
                    )
                );
            }

            // 3. Contagem Total (Deve ser feita antes da paginação)
            var totalCount = await query.CountAsync(cancellationToken);

            // 4. Ordenação
            switch (request.OrderBy?.ToLower())
            {
                case "reason":
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.Reason) :
                            query.OrderBy(a => a.Reason);
                    break;
                case "adjustmentdate": // Novo campo de ordenação
                    query = request.SortOrder?.ToLower() == "desc" ?
                           query.OrderByDescending(a => a.AdjustmentDate) :
                           query.OrderBy(a => a.AdjustmentDate);
                    break;
                case "responsible": // Ordenação pelo nome do responsável
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.Responsible!.Name) :
                            query.OrderBy(a => a.Responsible!.Name);
                    break;
                default:
                    // Padrão: Ordenar por data de criação (Id ou CreatedOn)
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(a => a.CreatedOn) :
                            query.OrderBy(a => a.CreatedOn);
                    break;
            }

            // 5. Paginação e Execução da Query
            var pagedAdjustments = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            // 6. Mapeamento
            var adjustmentDtos = _mapper.Map<List<StockAdjustmentDto>>(pagedAdjustments);

            return new PagedResponse<StockAdjustmentDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                adjustmentDtos
            );
        }
    }
}
