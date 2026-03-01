using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormById
{
    public class GetPresentationFormByIdQueryHandler : IRequestHandler<GetPresentationFormByIdQuery, Result<PresentationFormResponse>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public GetPresentationFormByIdQueryHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<Result<PresentationFormResponse>> Handle(
            GetPresentationFormByIdQuery request,
            CancellationToken cancellationToken)
        {
            var presentationForm = await _presentationFormRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (presentationForm is null)
                throw new NotFoundException("Forma de apresentação não foi encontrada.");

            var response = _mapper.Map<PresentationFormResponse>(presentationForm);

            return Result<PresentationFormResponse>.Success(
                response,
                "Forma de apresentação encontrada com sucesso.");
        }
    }
}
