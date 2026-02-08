using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.ExportFacilities
{
    public class ExportFacilitiesQueryHandler : IRequestHandler<ExportFacilitiesQuery, ApiResponse<FileResponse>>
    {
        private readonly IFacilityRepository _facilityRepository;

        public ExportFacilitiesQueryHandler(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportFacilitiesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _facilityRepository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower();

                query = query.Where(f =>
                    f.Name.ToLower().Contains(term) ||
                    f.Cnes.ToLower().Contains(term) ||
                    f.Address.Street.ToLower().Contains(term) ||
                    f.Address.Number.ToLower().Contains(term) ||
                    f.Address.Neighborhood.ToLower().Contains(term) ||
                    f.Address.City.ToLower().Contains(term) ||
                    f.Address.State.ToLower().Contains(term) ||
                    f.Address.Cep.ToLower().Contains(term) ||
                    f.Contact.Email.ToLower().Contains(term) ||
                    f.Contact.Phone.ToLower().Contains(term)
                );
            }

            var facilities = await query
                .OrderBy(s => s.Name)
                .ToListAsync(cancellationToken);

            if (!facilities.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty("unidade")
                );
            }

            var csvBytes = FacilityCsvExporter.Export(facilities);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"unidades_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
