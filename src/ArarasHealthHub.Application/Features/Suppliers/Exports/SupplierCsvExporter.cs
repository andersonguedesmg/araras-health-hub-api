using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Suppliers.Exports
{
    public static class SupplierCsvExporter
    {
        public static byte[] Export(IEnumerable<Supplier> suppliers)
        {
            var sb = new StringBuilder();

            sb.AppendLine("RAZÃO SOCIAL, NOME FANTASIA, CNPJ, RUA, NÚMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP, E-MAIL, TELEFONE, STATUS");

            foreach (var supplier in suppliers)
            {
                sb.AppendLine(
                    $"{supplier.LegalName}, " +
                    $"{supplier.TradeName}, " +
                    $"{supplier.Cnpj}, " +
                    $"{supplier.Address.Street}, " +
                    $"{supplier.Address.Number}, " +
                    $"{supplier.Address.Complement}, " +
                    $"{supplier.Address.Neighborhood}, " +
                    $"{supplier.Address.City}, " +
                    $"{supplier.Address.State}, " +
                    $"{supplier.Address.Cep}, " +
                    $"{supplier.Contact.Email}, " +
                    $"{supplier.Contact.Phone}, " +
                    $"{(supplier.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
