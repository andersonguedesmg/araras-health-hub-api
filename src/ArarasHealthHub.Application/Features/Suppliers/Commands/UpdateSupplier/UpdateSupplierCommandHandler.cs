using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSupplierCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(
            UpdateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (supplier is null)
                throw new NotFoundException("Fornecedor não encontrado.");

            var duplicate = await _context.Suppliers
                .AnyAsync(s => s.Cnpj == request.Cnpj && s.Id != request.Id, cancellationToken);

            if (duplicate)
                throw new DomainException("Já existe fornecedor com este CNPJ.");

            supplier.Update(
                request.LegalName,
                request.TradeName,
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

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success("Fornecedor atualizado com sucesso.");
        }
    }
}
