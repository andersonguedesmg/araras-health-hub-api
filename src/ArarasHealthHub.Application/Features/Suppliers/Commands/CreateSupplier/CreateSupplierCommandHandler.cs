using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateSupplierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(
            CreateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _context.Suppliers
                .AnyAsync(s => s.Cnpj == request.Cnpj, cancellationToken);

            if (exists)
                throw new DomainException("Já existe fornecedor com este CNPJ.");

            var supplier = new Supplier(
                request.LegalName,
                request.TradeName,
                request.Cnpj,
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

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(
                supplier.Id,
                "Fornecedor criado com sucesso."
            );
        }
    }
}
