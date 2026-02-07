using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.ExportSuppliers
{
    public class ExportSuppliersQueryHandler : IRequestHandler<ExportSuppliersQuery, ApiResponse<FileResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public ExportSuppliersQueryHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportSuppliersQuery request,
            CancellationToken cancellationToken)
        {
            var query = _supplierRepository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(s =>
                    s.LegalName.ToLower().Contains(term) ||
                    s.TradeName.ToLower().Contains(term) ||
                    s.Cnpj.ToLower().Contains(term) ||
                    s.Address.Street.ToLower().Contains(term) ||
                    s.Address.Number.ToLower().Contains(term) ||
                    s.Address.Neighborhood.ToLower().Contains(term) ||
                    s.Address.City.ToLower().Contains(term) ||
                    s.Address.State.ToLower().Contains(term) ||
                    s.Address.Cep.ToLower().Contains(term) ||
                    s.Contact.Email.ToLower().Contains(term) ||
                    s.Contact.Phone.ToLower().Contains(term)
                );
            }

            var suppliers = await query
                .OrderBy(s => s.LegalName)
                .ToListAsync(cancellationToken);

            if (!suppliers.Any())
            {
                return ApiResponse<FileResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty(EntityNames.Supplier)
                );
            }

            var csvBytes = SupplierCsvExporter.Export(suppliers);

            var fileResponse = new FileResponse
            {
                Content = csvBytes,
                ContentType = "text/csv",
                FileName = $"fornecedores_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
            };

            return ApiResponse<FileResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                fileResponse
            );
        }
    }
}
