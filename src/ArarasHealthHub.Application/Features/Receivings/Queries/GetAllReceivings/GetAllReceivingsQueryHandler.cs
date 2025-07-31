using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQueryHandler : IRequestHandler<GetAllReceivingsQuery, PagedResponse<ReceivingDto>>
    {
        private readonly IReceivingRepository _receivingRepository;
        private readonly IMapper _mapper;

        public GetAllReceivingsQueryHandler(IReceivingRepository receivingRepository, IMapper mapper)
        {
            _receivingRepository = receivingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ReceivingDto>> Handle(GetAllReceivingsQuery request, CancellationToken cancellationToken)
        {
            var query = _receivingRepository.AsQueryable();
            query = query
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivingItems)
                    .ThenInclude(ri => ri.Product);

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
                default:
                    query = request.SortOrder?.ToLower() == "desc" ?
                            query.OrderByDescending(r => r.Id) :
                            query.OrderBy(r => r.Id);
                    break;
            }

            var pagedReceivings = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var receivingDtos = _mapper.Map<List<ReceivingDto>>(pagedReceivings);

            return new PagedResponse<ReceivingDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                receivingDtos
            );
        }
    }
}
