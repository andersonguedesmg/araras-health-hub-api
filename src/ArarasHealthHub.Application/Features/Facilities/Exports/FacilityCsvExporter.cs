using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Facilities.Exports
{
    public static class FacilityCsvExporter
    {
        public static byte[] Export(IEnumerable<Facility> facilities)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NOME, CNES, RUA, NÚMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP, E-MAIL, TELEFONE, STATUS");

            foreach (var facility in facilities)
            {
                sb.AppendLine(
                    $"{facility.Name}, " +
                    $"{facility.Cnes}, " +
                    $"{facility.Address.Street}, " +
                    $"{facility.Address.Number}, " +
                    $"{facility.Address.Complement}, " +
                    $"{facility.Address.Neighborhood}, " +
                    $"{facility.Address.City}, " +
                    $"{facility.Address.State}, " +
                    $"{facility.Address.Cep}, " +
                    $"{facility.Contact.Email}, " +
                    $"{facility.Contact.Phone}, " +
                    $"{(facility.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
