using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm
{
    public class CreatePresentationFormCommandHandler : IRequestHandler<CreatePresentationFormCommand, Result<int>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public CreatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(
            CreatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var existingPresentationForm =
                await _presentationFormRepository.GetByPresentationFormNameAsync(
                    request.Name,
                    cancellationToken);

            if (existingPresentationForm is not null)
                throw new BusinessRuleException("Já existe um forma de apresentação com o nome informado.");

            var presentationForm = _mapper.Map<PresentationForm>(request);

            await _presentationFormRepository.AddAsync(presentationForm, cancellationToken);

            return Result<int>.Success(
                presentationForm.Id,
                "Forma de apresentação criada com sucesso.");
        }
    }
}
