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

namespace ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility
{
    public class CreateFacilityCommandHandler : IRequestHandler<CreateFacilityCommand, Result<int>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public CreateFacilityCommandHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Result<int>> Handle(
            CreateFacilityCommand request,
            CancellationToken cancellationToken)
        {
            var existingSupplier = await _facilityRepository
                    .ExistsByCnesAsync(request.Cnes, null, cancellationToken);

            if (existingSupplier)
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

            await _facilityRepository.AddAsync(facility, cancellationToken);

            return Result<int>.Success(
                facility.Id,
                "Unidade criada com sucesso.");
        }
    }
}
