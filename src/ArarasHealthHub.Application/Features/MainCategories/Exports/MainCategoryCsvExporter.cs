using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.MainCategories.Exports
{
    public class MainCategoryCsvExporter
    {
        public static byte[] Export(IEnumerable<MainCategory> mainCategories)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NOME, STATUS");

            foreach (var mainCategory in mainCategories)
            {
                sb.AppendLine(
                    $"{mainCategory.Name}, " +
                    $"{(mainCategory.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
