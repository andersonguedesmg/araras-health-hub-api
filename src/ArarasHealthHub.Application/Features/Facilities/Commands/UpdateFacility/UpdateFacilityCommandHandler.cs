using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public class UpdateFacilityCommandHandler : IRequestHandler<UpdateFacilityCommand, Result>
    {
        private readonly IFacilityRepository _facilityRepository;

        public UpdateFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Result> Handle(
            UpdateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (existingFacility is null)
                throw new NotFoundException("Unidade não encontrada.");

            var duplicate = await _facilityRepository
                .ExistsByCnesAsync(request.Cnes, null, cancellationToken);

            if (duplicate)
                throw new BusinessRuleException("Já existe uma unidade com este CNES.");

            var facility = new Facility(
                request.Name,
                request.Cnes,
                new Address(
                    request.Address.Cep,
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.Neighborhood,
                    request.Address.City,
                    request.Address.State,
                    request.Address.Complement
                ),
                new Contact(
                    request.Contact.Email,
                    request.Contact.Phone
                )
            );

            await _facilityRepository.UpdateAsync(facility, cancellationToken);

            return Result.Success("Unidade atualizada com sucesso.");
        }
    }
}
