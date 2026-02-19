using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById
{
    public class GetReceivingByIdQueryHandler : IRequestHandler<GetReceivingByIdQuery, ApiResponseO<ReceivingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReceivingByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<ReceivingDto>> Handle(GetReceivingByIdQuery request, CancellationToken cancellationToken)
        {
            var receiving = await _dbContext.Receivings
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivedItem)
                    .ThenInclude(ri => ri.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (receiving == null)
            {
                return new ApiResponseO<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Recebimento", request.Id), null);
            }

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);
            return new ApiResponseO<ReceivingDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Recebimento"), receivingDto);
        }
    }
}
