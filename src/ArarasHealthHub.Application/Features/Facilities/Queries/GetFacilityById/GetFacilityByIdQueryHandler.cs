using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById
{
    public class GetFacilityByIdQueryHandler : IRequestHandler<GetFacilityByIdQuery, Result<FacilityResponse>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public GetFacilityByIdQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<Result<FacilityResponse>> Handle(
            GetFacilityByIdQuery request,
            CancellationToken cancellationToken)
        {
            var facility = await _facilityRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.Id == request.Id)
                .Select(s => new FacilityResponse(
                    s.Id,
                    s.Name,
                    s.Cnes,
                    new AddressResponse(
                        s.Address.Street,
                        s.Address.Number,
                        s.Address.Complement,
                        s.Address.Neighborhood,
                        s.Address.City,
                        s.Address.State,
                        s.Address.Cep
                    ),
                    new ContactResponse(
                        s.Contact.Email,
                        s.Contact.Phone
                    ),
                    s.CreatedOn,
                    s.UpdatedOn,
                    s.IsActive
                ))
                .FirstOrDefaultAsync(cancellationToken);

            if (facility is null)
                throw new NotFoundException("Unidade não encontrada.");

            return Result<FacilityResponse>.Success(
                facility,
                "Unidade encontrada com sucesso.");
        }
    }
}
