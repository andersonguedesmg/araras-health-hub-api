using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.ExportPresentationForms
{
    public class ExportPresentationFormsQueryHandler : IRequestHandler<ExportPresentationFormsQuery, ApiResponse<FileResponse>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public ExportPresentationFormsQueryHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportPresentationFormsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _presentationFormRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(p =>
                    p.Name.ToLower().Contains(term)
                );
            }

            var mainCategories = await query
                .OrderBy(p => p.Name)
                .ToListAsync(cancellationToken);

            if (!mainCategories.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty("forma de apresentação")
                );
            }

            var csvBytes = PresentationFormCsvExporter.Export(mainCategories);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"formas_de_apresentacao_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
