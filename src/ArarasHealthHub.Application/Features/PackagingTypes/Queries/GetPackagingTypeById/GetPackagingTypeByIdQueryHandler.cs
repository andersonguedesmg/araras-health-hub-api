using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetPackagingTypeById
{
    public class GetPackagingTypeByIdQueryHandler : IRequestHandler<GetPackagingTypeByIdQuery, Result<PackagingTypeResponse>>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public GetPackagingTypeByIdQueryHandler(IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<Result<PackagingTypeResponse>> Handle(
            GetPackagingTypeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var packagingType = await _packagingTypeRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (packagingType is null)
                throw new NotFoundException("Tipo de embalagem não foi encontrado.");

            var response = new PackagingTypeResponse(
                packagingType.Id,
                packagingType.Name,
                packagingType.CreatedOn,
                packagingType.UpdatedOn,
                packagingType.IsActive
            );

            return Result<PackagingTypeResponse>.Success(
                response,
                "Tipo de embalagem encontrado com sucesso.");
        }
    }
}
