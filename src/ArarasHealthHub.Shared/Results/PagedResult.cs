using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Results
{
    public class PagedResult<T> : Result<IReadOnlyList<T>>
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        private PagedResult(
            IReadOnlyList<T> data,
            int pageNumber,
            int pageSize,
            int totalCount,
            string message)
            : base(data, message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static PagedResult<T> Success(
            IReadOnlyList<T> data,
            int pageNumber,
            int pageSize,
            int totalCount,
            string message = "Dados listados com sucesso.")
            => new(data, pageNumber, pageSize, totalCount, message);
    }
}
