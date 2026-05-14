using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById
{
    public sealed class GetReceivingByIdQueryHandler : IRequestHandler<GetReceivingByIdQuery, Result<ReceivingResponse>>
    {
        private readonly IReceivingRepository _receivingRepository;
        private readonly IMapper _mapper;

        public GetReceivingByIdQueryHandler(
            IReceivingRepository receivingRepository,
            IMapper mapper)
        {
            _receivingRepository = receivingRepository;
            _mapper = mapper;
        }

        public async Task<Result<ReceivingResponse>> Handle(
            GetReceivingByIdQuery request,
            CancellationToken cancellationToken)
        {
            var receiving = await _receivingRepository
                .GetByIdWithDetailsAsync(
                    request.Id,
                    cancellationToken);

            if (receiving is null)
            {
                throw new NotFoundException(
                    "Recebimento não foi encontrado.");
            }

            var response = _mapper.Map<ReceivingResponse>(
                receiving);

            return Result<ReceivingResponse>.Success(
                response,
                "Recebimento encontrado com sucesso.");
        }
    }
}
