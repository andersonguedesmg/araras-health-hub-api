using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById
{
    public class GetReceivingByIdQueryHandler : IRequestHandler<GetReceivingByIdQuery, ApiResponse<ReceivingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReceivingByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReceivingDto>> Handle(GetReceivingByIdQuery request, CancellationToken cancellationToken)
        {
            var receiving = await _dbContext.Receivings
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivingItems)
                    .ThenInclude(ri => ri.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (receiving == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"Recebimento com ID {request.Id} não encontrado.", false);
            }

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);
            return new ApiResponse<ReceivingDto>(StatusCodes.Status200OK, "Busca por ID realizada com sucesso.", receivingDto);
        }
    }
}
