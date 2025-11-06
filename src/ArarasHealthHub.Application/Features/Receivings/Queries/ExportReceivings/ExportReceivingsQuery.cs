using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.ExportReceivings
{
    public class ExportReceivingsQuery : IRequest<IEnumerable<ReceivingExportDetailDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
