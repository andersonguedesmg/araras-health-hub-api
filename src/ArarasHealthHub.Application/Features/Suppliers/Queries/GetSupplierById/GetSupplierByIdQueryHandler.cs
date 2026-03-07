using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Result<SupplierResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierByIdQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Result<SupplierResponse>> Handle(
            GetSupplierByIdQuery request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.Id == request.Id)
                .Select(s => new SupplierResponse(
                    s.Id,
                    s.LegalName,
                    s.TradeName,
                    s.Cnpj,
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

            if (supplier is null)
                throw new NotFoundException("Fornecedor não encontrado.");

            return Result<SupplierResponse>.Success(
                supplier,
                "Fornecedor encontrado com sucesso.");
        }
    }
}
