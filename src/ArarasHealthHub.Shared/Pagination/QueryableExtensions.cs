using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Pagination
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(
            this IQueryable<T> query,
            string? orderBy,
            string sortOrder,
            Dictionary<string, Expression<Func<T, object>>> columns)
        {
            if (string.IsNullOrWhiteSpace(orderBy) || !columns.ContainsKey(orderBy))
                return query;

            return sortOrder == "desc"
                ? query.OrderByDescending(columns[orderBy])
                : query.OrderBy(columns[orderBy]);
        }

        public static IQueryable<T> ApplyPagination<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
