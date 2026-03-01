using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm
{
    public class UpdatePresentationFormCommandHandler : IRequestHandler<UpdatePresentationFormCommand, Result>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public UpdatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var existingPresentationForm =
                await _presentationFormRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (existingPresentationForm is null)
                throw new NotFoundException("Forma de apresentação não foi encontrada.");


            _mapper.Map(request, existingPresentationForm);
            existingPresentationForm.SetUpdatedOn();

            await _presentationFormRepository.UpdateAsync(
                existingPresentationForm,
                cancellationToken);

            return Result.Success("Forma de apresentação atualizada com sucesso.");
        }
    }
}
