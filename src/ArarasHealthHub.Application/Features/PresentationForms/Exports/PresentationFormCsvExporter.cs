using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.PresentationForms.Exports
{
    public class PresentationFormCsvExporter
    {
        public static byte[] Export(IEnumerable<PresentationForm> presentationForms)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NOME, STATUS");

            foreach (var presentationForm in presentationForms)
            {
                sb.AppendLine(
                    $"{presentationForm.Name}, " +
                    $"{(presentationForm.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
