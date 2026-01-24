using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Products.Exports
{
    public static class ProductCsvExporter
    {
        public static byte[] Export(IEnumerable<Product> products)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NOME, DESCRIÇÃO, CATEGORIA PRINCIPAL, SUBCATEGORIA, FORMA DE APRESENTAÇÃO, STATUS");

            foreach (var product in products)
            {
                sb.AppendLine(
                    $"{product.Name}, " +
                    $"{product.Description}, " +
                    $"{product.MainCategory!.Name}, " +
                    $"{product.SubCategory!.Name}, " +
                    $"{product.PresentationForm!.Name}, " +
                    $"{(product.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
