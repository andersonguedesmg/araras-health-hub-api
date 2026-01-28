using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.SubCategories.Exports
{
    public static class SubCategoryCsvExporter
    {
        public static byte[] Export(IEnumerable<SubCategory> subCategories)
        {
            var sb = new StringBuilder();

            sb.AppendLine("SUBCATEGORIA, CATEGORIA PRINCIPAL, STATUS");

            foreach (var subCategory in subCategories)
            {
                sb.AppendLine(
                    $"{subCategory.Name}, " +
                    $"{subCategory.MainCategory?.Name}, " +
                    $"{(subCategory.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
