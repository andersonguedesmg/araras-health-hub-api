using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.ActivatePresentationForm
{
    public class ActivatePresentationFormCommandHandler : IRequestHandler<ActivatePresentationFormCommand, Result>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public ActivatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<Result> Handle(
            ActivatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var presentationForm = await _presentationFormRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (presentationForm is null)
                throw new NotFoundException("Forma de apresentação não foi encontrada.");

            if (presentationForm.IsActive)
                throw new BusinessRuleException("A forma de apresentação já está ativa.");

            presentationForm.Activate();

            await _presentationFormRepository
                .UpdateAsync(presentationForm, cancellationToken);

            return Result.Success("Forma de apresentação ativada com sucesso.");
        }
    }
}
