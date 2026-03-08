using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility
{
    public class DeactivateFacilityCommandHandler : IRequestHandler<DeactivateFacilityCommand, Result>
    {
        private readonly IFacilityRepository _facilityRepository;

        public DeactivateFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Result> Handle(
            DeactivateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (facility is null)
                throw new NotFoundException("Unidade não foi encontrada.");

            if (!facility.IsActive)
                throw new BusinessRuleException("O unidade já está inativa.");

            facility.Deactivate();

            await _facilityRepository
                .UpdateAsync(facility, cancellationToken);

            return Result.Success("Unidade desativada com sucesso.");
        }
    }
}
