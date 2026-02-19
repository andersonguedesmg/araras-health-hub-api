using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Pagination
{
    public class PagedRequest
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;

        public string? OrderBy { get; init; }
        public string SortOrder { get; init; } = "asc";

        public string? SearchTerm { get; init; }
    }
}
