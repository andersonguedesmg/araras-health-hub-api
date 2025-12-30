using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.ExportReceivings
{
    public class ExportReceivingsQueryHandler : IRequestHandler<ExportReceivingsQuery, IEnumerable<ReceivingExportDetailDto>>
    {
        private readonly IReceivingRepository _receivingRepository;

        public ExportReceivingsQueryHandler(IReceivingRepository receivingRepository)
        {
            _receivingRepository = receivingRepository;
        }

        public async Task<IEnumerable<ReceivingExportDetailDto>> Handle(ExportReceivingsQuery request, CancellationToken cancellationToken)
        {
            var query = _receivingRepository.AsQueryable();
            query = query
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.ReceivedItem)
                    .ThenInclude(ri => ri.Product);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(r =>
                    r.Id.ToString().Contains(searchTermLower) ||
                    r.InvoiceNumber.ToLower().Contains(searchTermLower) ||
                    r.SupplyAuthorization.ToLower().Contains(searchTermLower) ||
                    r.Observation!.ToLower().Contains(searchTermLower) ||
                    r.ReceivingDate.ToString().Contains(searchTermLower) ||
                    r.TotalValue.ToString().Contains(searchTermLower) ||
                    (r.Supplier != null && r.Supplier.LegalName.ToLower().Contains(searchTermLower)) ||
                    (r.Supplier != null && r.Supplier.TradeName.ToLower().Contains(searchTermLower)) ||
                    (r.Responsible != null && r.Responsible.Name.ToLower().Contains(searchTermLower)) ||
                    (r.Account != null && r.Account.UserName!.ToLower().Contains(searchTermLower)) ||

                    r.ReceivedItem.Any(ri =>
                        ri.Batch.ToLower().Contains(searchTermLower) ||
                        ri.Brand.ToLower().Contains(searchTermLower) ||
                        ri.Product.Name.ToLower().Contains(searchTermLower)
                    )
                );
            }

            var flatListQuery = query
                .SelectMany(r => r.ReceivedItem, (r, ri) => new ReceivingExportDetailDto
                {
                    ReceivingId = r.Id,
                    InvoiceNumber = r.InvoiceNumber,
                    SupplyAuthorization = r.SupplyAuthorization,
                    ReceivingDate = r.ReceivingDate,
                    SupplierLegalName = r.Supplier!.LegalName,
                    SupplierTradeName = r.Supplier!.TradeName,
                    ResponsibleName = r.Responsible!.Name,
                    Observation = r.Observation,
                    ProductName = ri.Product.Name,
                    Batch = ri.Batch,
                    Brand = ri.Brand,
                    ExpiryDate = ri.ExpiryDate,
                    QuantityReceived = ri.Quantity,
                    UnitValue = ri.UnitValue,
                })
                .OrderByDescending(d => d.ReceivingDate);

            var flatList = await flatListQuery.ToListAsync(cancellationToken);

            return flatList;
        }
    }
}
