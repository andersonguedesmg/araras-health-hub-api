using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById
{
    public class GetReceivingByIdQueryHandler : IRequestHandler<GetReceivingByIdQuery, ApiResponse<ReceivingDto>>
    {
        private readonly IReceivingRepository _receivingRepository;
        private readonly IMapper _mapper;

        public GetReceivingByIdQueryHandler(IReceivingRepository receivingRepository, IMapper mapper)
        {
            _receivingRepository = receivingRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ReceivingDto>> Handle(GetReceivingByIdQuery request, CancellationToken cancellationToken)
        {
            var receiving = await _receivingRepository.GetByIdWithDetailsAsync(request.Id);

            if (receiving == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, "Recebimento não encontrado.", null!);
            }

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);

            return new ApiResponse<ReceivingDto>(StatusCodes.Status200OK, "Recebimento encontrado com sucesso.", receivingDto);
        }
    }
}
