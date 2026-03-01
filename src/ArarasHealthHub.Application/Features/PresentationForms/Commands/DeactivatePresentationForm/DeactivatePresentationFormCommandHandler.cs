using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeactivatePresentationForm
{
    public class DeactivatePresentationFormCommandHandler : IRequestHandler<DeactivatePresentationFormCommand, Result>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public DeactivatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<Result> Handle(
            DeactivatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var presentationForm = await _presentationFormRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (presentationForm is null)
                throw new NotFoundException("Forma de apresentação não foi encontrada.");

            if (!presentationForm.IsActive)
                throw new BusinessRuleException("A Forma de apresentação já está inativa.");

            presentationForm.Deactivate();

            await _presentationFormRepository
                .UpdateAsync(presentationForm, cancellationToken);

            return Result.Success("Forma de apresentação desativada com sucesso.");
        }
    }
}
