using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQueryHandler : IRequestHandler<GetAllReceivingsQuery, PagedResponseO<ReceivingDto>>
    {
        private readonly IReceivingRepository _receivingRepository;
        private readonly IMapper _mapper;

        public GetAllReceivingsQueryHandler(IReceivingRepository receivingRepository, IMapper mapper)
        {
            _receivingRepository = receivingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseO<ReceivingDto>> Handle(GetAllReceivingsQuery request, CancellationToken cancellationToken)
        {
            var query = _receivingRepository.AsQueryable();

            query = query
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivedItems)
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

                    r.ReceivedItems.Any(ri =>
                        ri.Batch.ToLower().Contains(searchTermLower) ||
                        ri.Brand.ToLower().Contains(searchTermLower) ||
                        ri.Product.Name.ToLower().Contains(searchTermLower)
                    )
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy?.ToLower())
            {
                case "invoicenumber":
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(r => r.InvoiceNumber) :
                            query.OrderBy(r => r.InvoiceNumber);
                    break;
                case "receivingdate":
                    query = request.SortOrder?.ToLower() == "desc" ?
                           query.OrderByDescending(r => r.ReceivingDate) :
                           query.OrderBy(r => r.ReceivingDate);
                    break;
                case "supplierlegalname":
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(r => r.Supplier!.LegalName) :
                            query.OrderBy(r => r.Supplier!.LegalName);
                    break;
                case "suppliertradename":
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(r => r.Supplier!.TradeName) :
                            query.OrderBy(r => r.Supplier!.TradeName);
                    break;
                default:
                    query = request.SortOrder?.ToLower() == "asc" ?
                            query.OrderByDescending(r => r.CreatedOn) :
                            query.OrderBy(r => r.CreatedOn);
                    break;
            }

            var pagedReceivings = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var receivingDtos = _mapper.Map<List<ReceivingDto>>(pagedReceivings);

            return new PagedResponseO<ReceivingDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                receivingDtos
            );
        }
    }
}
