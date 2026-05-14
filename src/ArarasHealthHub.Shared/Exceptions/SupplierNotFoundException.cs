using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public sealed class SupplierNotFoundException : NotFoundException
    {
        public SupplierNotFoundException(int supplierId)
            : base($"Fornecedor com ID {supplierId} não foi encontrado.")
        {
        }
    }
}
