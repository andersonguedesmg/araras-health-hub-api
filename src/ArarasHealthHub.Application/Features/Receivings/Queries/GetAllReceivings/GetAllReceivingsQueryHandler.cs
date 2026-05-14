using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQueryHandler : IRequestHandler<GetAllReceivingsQuery, PagedResult<ReceivingListItemResponse>>
    {
        private readonly IReceivingRepository _receivingRepository;

        public GetAllReceivingsQueryHandler(
            IReceivingRepository receivingRepository)
        {
            _receivingRepository = receivingRepository;
        }

        public async Task<PagedResult<ReceivingListItemResponse>> Handle(
            GetAllReceivingsQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Receiving> query = _receivingRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Supplier)
                .Include(x => x.Responsible)
                .Include(x => x.Account)
                .Include(x => x.Items)
                    .ThenInclude(x => x.Product);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(r =>
                    EF.Functions.Like(r.InvoiceNumber, $"%{term}%") ||
                    EF.Functions.Like(r.SupplyAuthorization, $"%{term}%") ||

                    (r.Observation != null &&
                     EF.Functions.Like(r.Observation, $"%{term}%")) ||

                    EF.Functions.Like(
                        r.Supplier!.LegalName,
                        $"%{term}%") ||

                    EF.Functions.Like(
                        r.Supplier.TradeName,
                        $"%{term}%") ||

                    EF.Functions.Like(
                        r.Responsible!.Name,
                        $"%{term}%") ||

                    EF.Functions.Like(
                        r.Account!.UserName!,
                        $"%{term}%") ||

                    r.Items.Any(i =>
                        EF.Functions.Like(i.Batch, $"%{term}%") ||
                        EF.Functions.Like(i.Brand, $"%{term}%") ||
                        EF.Functions.Like(i.Product.Name, $"%{term}%")));
            }

            var totalCount = await query
                .CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "invoicenumber" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.InvoiceNumber)
                    : query.OrderBy(x => x.InvoiceNumber),

                "receivingdate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.ReceivingDate)
                    : query.OrderBy(x => x.ReceivingDate),

                "supplierlegalname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Supplier!.LegalName)
                    : query.OrderBy(x => x.Supplier!.LegalName),

                "suppliertradename" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Supplier!.TradeName)
                    : query.OrderBy(x => x.Supplier!.TradeName),

                "totalvalue" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.TotalValue)
                    : query.OrderBy(x => x.TotalValue),

                _ => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.CreatedOn)
                    : query.OrderBy(x => x.CreatedOn)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(r => new ReceivingListItemResponse(
                    r.Id,
                    r.InvoiceNumber,
                    r.SupplyAuthorization,
                    r.ReceivingDate,
                    r.TotalValue,

                    r.SupplierId,
                    r.Supplier!.TradeName,

                    r.ResponsibleId,
                    r.Responsible!.Name,

                    r.Items.Count,

                    r.CreatedOn,
                    r.IsActive
                ))
                .ToListAsync(cancellationToken);

            return PagedResult<ReceivingListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Recebimentos listados com sucesso.");
        }
    }
}
